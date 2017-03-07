using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float maxSpeed = 2;
    public float acceleration = 1;
    public float drag = 0.5f;
    public float gravity = 10;
    public float RotationRate = 90;
    public float AggressionDist = 5;

    public GameObject PatrolGraph;
    private List<int> CurrentPath = new List<int>();
    private int targetNodeIndex;
    private Vector3 targetNode;
    private List<Vector3> nodes;
    private List<List<int>> edges;
    private Vector3 eye;
    private Transform eyeTransform;
    private GameObject player;
    private Rigidbody rb;
    private bool inAir = false;
	// Use this for initialization
	void Start ()
    {
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
        eye = eyeTransform.position;
        if (player == null) {
            Debug.Log("no player in scene");
            return;
        }
        if (PlayerInSight())
        {
            RotateTowards(player.transform.position);
            MoveTowards(player.transform.position);
        }
        else {
            if (PatrolGraph == null) {
                return;
            }
            if (!ValidTarget(targetNode)) {
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
                    inPath[adj] = true;
                    CurrentPath.Add(adj);
                    failed = false;
                    break;
                }
            }
            if (failed) {
                break;
            }
        }
        return true;
    }
    int NearestViableNode()
    {
        int curr = -1;
        for (int i = 0; i < nodes.Count; i++) {
            float dist = Vector3.Distance(nodes[i], transform.position);
            if (dist < float.MaxValue && !Physics.Linecast(transform.position, nodes[i], ~(1 << 8))) {
                curr = i;
            }
        }

        return curr;
    }

    bool ValidTarget(Vector3 target) {
        return (!Physics.Linecast(transform.position, target, ~(1 << 8))) && (transform.position - target).magnitude > 1;
    }

    bool PlayerInSight()
    {
        Vector3 toPlayer = player.transform.position - eye;
        RaycastHit hitinfo;
        Physics.Raycast(eye, toPlayer,out hitinfo,AggressionDist, ~(1 << 8));
        if (hitinfo.collider != null) {
            return hitinfo.collider.gameObject.transform.tag == "Player";
        }
        return false;
    }
    void RotateTowards(Vector3 point) {
        Vector3 toTarget = point - transform.position;
        float det = toTarget.x * transform.right.y - toTarget.y * transform.right.x;
        float anglediff = Vector3.Angle(transform.right, toTarget);
        if (anglediff > RotationRate * Time.deltaTime) {
            anglediff = RotationRate * Time.deltaTime * Mathf.Sign(-det);
            toTarget = Quaternion.Euler(0, 0, anglediff) * transform.right;
          /*  Debug.Log("Limit:" + MaxRotateAngle * Time.deltaTime);
            Debug.Log("After:" + anglediff);
            Debug.Log("Vector angle:" +Vector3.Angle(transform.right, toTarget));*/
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
                vel = vel - (vel * drag * Time.deltaTime);
            }
            if (Vector3.Angle(dir, transform.right) < 90)
            {
                vel = vel + new Vector3(dir.x, dir.y, 0) * Time.deltaTime * acceleration;
            }
            if (vel.magnitude > maxSpeed)
            {
                vel = vel.normalized * maxSpeed;
            }
        }
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
}
