using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI: RespawnableBehavior{

    public float maxSpeed = 2;
    public float acceleration = 1;
    public float drag = 0.5f;
    public float gravity = 10;
    public float RotationRate = 90;
    public float AggressionDist = 5;
    public float SonarAggressionDist = 80;
    public float SonarAggressionTime = 11;
    public float AggressiveModifier = 2;
    public bool PrefersHomeNodes = true;
    public bool UseSpecialRouting = false;
    //public bool IgnoreHomeinAnger = false;

    public AudioSource alertSound;
    public AudioSource seePlayerSound;

    public GameObject PatrolGraph;

    private int IgnoredLayers;
    private bool StayHome;
    private float ANGERY = 0;
    private float modifier = 1;
    private bool canBeTriggered = false;
    private bool wasAttackingPlayer = false;
    private float triggerTime;
    private float triggerCD;
    private Vector3 triggerOrigin;
    private List<Vector3> nodes;
    private List<List<int>> edges;
    private List<bool> home;
    private List<int> CurrentPath = new List<int>();
    private int targetNodeIndex;
    private Vector3 targetNode;
    private Vector3 eye;
    private Transform eyeTransform;
    private GameObject player;
    private Rigidbody rb;
    private bool inAir = false;
    private Material mat;
    private Color passiveColor = new Color(255, 255, 0);
    private Color aggressiveColor = new Color(255, 0, 0);
    // Use this for initialization
    void Start ()
    {
        mat = GetComponentInChildren<Renderer>().material;
        IgnoredLayers = 1 << 8 | 1 << 11 | 1 << 13;
        if (PrefersHomeNodes) {
            StayHome = true;
        }
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (PatrolGraph == null)
        {
            Debug.Log("No patrolGraph, AI will stay still if no player around");
        }
        else {
            var script = PatrolGraph.GetComponent<PatrolGraph>();
            nodes = script.Nodes;
            edges = new List<List<int>>();
            home = script.Home;
            foreach (PatrolGraph.ListWrapper l in script.Edges) {
                edges.Add(l.myList);
            }
            if (nodes.Count == 0) {
                Debug.Log("No nodes in PatrollGraph");
            }
            targetNodeIndex = 0;
            targetNode = nodes[0];
        }
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform t in children) {
            if (t.name == "Eye") {
                eyeTransform = t;
                return;
            }
        }
        Debug.Log("enemy " + transform.name + " has no Eye");
	}
	
	// Update is called once per frame
	void Update () {
        triggerCD -= Time.deltaTime;
        // used to delay the triggering of the AI by sonar according to the sonar's propogation speed
        if (triggerTime < 0 && canBeTriggered)
        {
            canBeTriggered = false;
            alertSound.Play();
            Triggered();
            modifier = AggressiveModifier;
        }
        else {
            triggerTime -= Time.deltaTime;
        }
        eye = eyeTransform.position;
        if (player == null) {
            Debug.Log("no player in scene");
            return;
        }
        float sightDist = AggressionDist;
        if (ANGERY > 0){
            sightDist = AggressionDist * 10;
           // alertSound.Play();
            mat.SetColor("_EmissionColor", aggressiveColor);
        }else{
            mat.SetColor("_EmissionColor", passiveColor);
        }
        if (PlayerInSight(sightDist))
        {
            seePlayerSound.loop = true;
            if (!seePlayerSound.isPlaying) {
                seePlayerSound.Play();
            }
            wasAttackingPlayer = true;
            mat.SetColor("_EmissionColor", aggressiveColor);
            modifier = AggressiveModifier;
            RotateTowards(player.transform.position);
            MoveTowards(player.transform.position);
        }
        else
        {
            seePlayerSound.loop = false;
            if (wasAttackingPlayer) {
                TrimPath();
            }
            wasAttackingPlayer = false;
            if (PatrolGraph == null) {
                return;
            }
            if (!ValidTarget(targetNode)) {
                if (StayHome && home[targetNodeIndex] && NearestViableNode() < 0) {
                    StayHome = false;
                }
                if (ANGERY <= 0)
                {
                    modifier = 1;
                }
                if (ExtendCurrentPath()) {
                    targetNodeIndex = CurrentPath[0];
                    targetNode = nodes[targetNodeIndex];
                    CurrentPath.RemoveAt(0);
                }else {
                    Debug.Log("No viable nodes");
                    return;
                }
            }
            RotateTowards(targetNode);
            MoveTowards(targetNode);
        }
        ANGERY -= Time.deltaTime;
        DrawPath();
	}
    void DrawPath() {
        Debug.DrawLine(transform.position, targetNode, Color.red);
        if (CurrentPath.Count > 0)
        {
            Debug.DrawLine(nodes[CurrentPath[0]], targetNode, Color.yellow);
        }
        for (int i = 1; i < CurrentPath.Count; i++) {
            Debug.DrawLine(nodes[CurrentPath[i - 1]], nodes[CurrentPath[i]],Color.green);
        }
    }
    bool GraphReachable() {
        RaycastHit hitinfo;
        foreach (Vector3 loc in nodes) {
            if (!Physics.Linecast(loc, player.transform.position,out hitinfo, ~IgnoredLayers))
            {
                Debug.DrawLine(loc, player.transform.position, Color.green,5);
                return true;
            }
            else {
                Debug.DrawLine(loc, hitinfo.point, Color.red, 5);
            }
        }
        return false;
    }

    void TrimPath() {
        float bestAngle = Vector3.Angle(transform.right, targetNode - eye);
        int bestindex = -1;
        foreach (int i in CurrentPath) {
            if (!Physics.Linecast(transform.position, nodes[i], ~IgnoredLayers)) {
                float angle = Vector3.Angle(transform.right, nodes[i] - eye);
                if (angle < bestAngle) {
                    bestAngle = angle;
                    bestindex = i;
                }
            }
        }
        if (bestindex >= 0) {
            while (CurrentPath[0] != bestindex) {
                CurrentPath.RemoveAt(0);
            }
            targetNodeIndex = bestindex;
            targetNode = nodes[bestindex];
            CurrentPath.RemoveAt(0);
        }
    }

    void Triggered()
    {
        int curr = -1;
        float bestDist = float.MaxValue;
        CurrentPath.Clear();
        Vector3 toNode = Vector3.zero;
        for (int i = 0; i < nodes.Count; i++)
        {
            float dist = Vector3.Distance(nodes[i], triggerOrigin);
            if (dist < bestDist && !Physics.Linecast(transform.position, nodes[i], ~IgnoredLayers) && !home[i])
            {
                bestDist = dist;
                curr = i;
            }
        }
        if (curr < 0) {
            Debug.Log("Enemy could not be ANGERY!");
            return;
        }
        toNode = nodes[curr] - transform.position;
        CurrentPath.Add(curr);
        StayHome = false;
        ANGERY = SonarAggressionTime;
        targetNodeIndex = curr;
        targetNode = nodes[curr];
        int champ = minDist(edges[curr], bestDist);
        int counter = 0;
        if (UseSpecialRouting)
        {
            ExtendCurrentPathSpecial(curr, toNode);
        }
        else
        {
            while (champ >= 0 && counter < 20) {
                CurrentPath.Add(champ);
                float champDist = Vector3.Distance(nodes[champ], triggerOrigin);
                champ = minDist(edges[champ], champDist);
                counter++;
            }
            ExtendCurrentPath();
        }
    }

    int minDist(List<int> adj, float best) {
        int champ = -1;
        for (int i = 0; i < adj.Count; i++) {
            float dist = Vector3.Distance(nodes[adj[i]], triggerOrigin);
            if (dist < best && !home[i]) {
                best = dist;
                champ = adj[i];
            }
        }
        return champ;
    }

    bool ExtendCurrentPath() {
        bool[] inPath = new bool[nodes.Count];
        for (int i = 0; i < CurrentPath.Count; i++) {
            inPath[CurrentPath[i]] = true;
        }
        if (CurrentPath.Count == 0) {
            int viable = NearestViableNode();
            if (viable < 0) {
                return false;
            }
            CurrentPath.Add(viable);
        }
        while (true) {
            int last = CurrentPath[CurrentPath.Count - 1];
            bool failed = true;
            for (int j = 0; j < edges[last].Count; j++) {
                int adj = edges[last][j];
                if (!inPath[adj]) {
                    if (StayHome && home[adj])
                    {
                        inPath[adj] = true;
                        CurrentPath.Add(adj);
                        failed = false;
                        break;
                    }
                    else if (!StayHome)
                    {
                        inPath[adj] = true;
                        CurrentPath.Add(adj);
                        failed = false;
                        break;
                    }
                }
            }
            if (failed) {
                break;
            }
        }
        return true;
    }


    bool ExtendCurrentPathSpecial(int curr, Vector3 toNode)
    {
        bool[] inPath = new bool[nodes.Count];
        for (int i = 0; i < CurrentPath.Count; i++)
        {
            inPath[CurrentPath[i]] = true;
        }
        while (true)
        {
            bool failed = true;
            int best = -1;
            float bestVal = 200;
            for (int j = 0; j < edges[curr].Count; j++)
            {
                int adj = edges[curr][j];
                if (!inPath[adj])
                {
                    Vector3 toNodeTemp = nodes[adj] - nodes[curr];
                    float val = Vector3.Angle(toNodeTemp, toNode);
                    if (val < bestVal) {
                        bestVal = val;
                        best = adj;
                    }
                    failed = false;
                }
            }
            if (failed)
            {
                break;
            }
            toNode = nodes[best] - nodes[curr];
            curr = best;
            inPath[best] = true;
            CurrentPath.Add(best);
        }
        return true;
    }

    int NearestViableNode()
    {
        int curr = -1;
        for (int i = 0; i < nodes.Count; i++) {
            if (!Physics.Linecast(transform.position, nodes[i], ~IgnoredLayers)) {
                if (StayHome)
                {
                    if (home[i])
                    {
                        curr = i;
                    }
                }
                else {
                    curr = i;
                }
            }
        }

        return curr;
    }

    bool ValidTarget(Vector3 target) {
        if ((transform.position - target).magnitude > 2) {
            if (!StayHome && ANGERY <= 0) {
                if (home[targetNodeIndex] && PrefersHomeNodes && !Physics.Linecast(transform.position, target, ~(1 << 8))) {
                    StayHome = true;
                    CurrentPath.Clear();
                }
            }
            return (!Physics.Linecast(transform.position, target, ~IgnoredLayers));
        }
        return false;
        
    }

    bool PlayerInSight(float Dist)
    {
        Vector3 toPlayer = player.transform.position - eye;
        RaycastHit hitinfo;
        Physics.Raycast(eye, toPlayer,out hitinfo,Dist, ~(IgnoredLayers) | 1 << 11);
        if (hitinfo.collider != null) {
            return hitinfo.collider.gameObject.tag == "Player";
        }
        return false;
    }
    void RotateTowards(Vector3 point) {
        Vector3 toTarget = point - transform.position;
        float det = toTarget.x * transform.right.y - toTarget.y * transform.right.x;
        float anglediff = Vector3.Angle(transform.right, toTarget);
        if (anglediff > RotationRate * Time.deltaTime*modifier) {
            anglediff = RotationRate * Time.deltaTime * Mathf.Sign(-det)*modifier;
            toTarget = Quaternion.Euler(0, 0, anglediff) * transform.right;
        }
        float angle = Vector3.Angle(Vector3.right, toTarget);
        angle *= Mathf.Sign(toTarget.y);
        Vector3 angles = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void MoveTowards(Vector3 nodePos)
    {
        Vector3 toTarget = nodePos - transform.position;
        Move(toTarget);
    }

    void Move(Vector2 dir)
    {
        Vector3 vel = rb.velocity;

        if (inAir)
        {
            vel -= new Vector3(0, gravity, 0) * Time.deltaTime;
        }
        else
        {
            if (dir.magnitude < 0.5 || Vector3.Angle(dir, vel) > 90 || Vector3.Angle(dir, transform.right) > 90)
            {
                vel = vel - (vel * drag * Time.deltaTime)*modifier;
            }
            if (Vector3.Angle(dir, transform.right) < 90)
            {
                vel = vel + new Vector3(dir.x, dir.y, 0) * Time.deltaTime * acceleration*modifier;
            }
            if (vel.magnitude > maxSpeed*modifier)
            {
                vel = vel.normalized * maxSpeed*modifier;
            }
        }
        rb.angularVelocity = Vector3.zero;
        rb.velocity = vel;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Air")
        {
            inAir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "Air")
        {
            inAir = false;
        }
    }

    // for respawning on player death

    private Vector3 myCheckpointLocation;

    void Awake()
    {
        myCheckpointLocation = transform.position;
    }
    public override void Respawn(Vector3 checkpointLocation)
    {
        transform.position = myCheckpointLocation;
        ANGERY = 0;
        targetNode = Vector3.up * 99999;
        CurrentPath.Clear();
    }

    public void SonarActivated(float SonarSpeed){
        if (Vector3.Distance(transform.position, player.transform.position) < SonarAggressionDist)
        {
            if (GraphReachable())
            {
                canBeTriggered = true;
                triggerTime = Vector3.Distance(transform.position, player.transform.position) / SonarSpeed;
                triggerOrigin = player.transform.position;
            }
        }
    }
}
