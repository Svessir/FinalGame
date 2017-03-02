using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float maxSpeed = 10;
    public float acceleration = 2;
    public float drag = 1;
    public float gravity = 10;
    public float MaxRotateAngle = 10;
    public float AggressionDist = 5;

    public GameObject PatrolGraph;
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
            edges = script.Edges;
            if (nodes.Count == 0) {
                Debug.Log("No nodes in PatrollGraph");
            }
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
                List<Vector3> viable = GetViableNodes();
                if (viable.Count > 0)
                {
                    targetNode = viable[Random.Range(0, viable.Count)];
                }
                else {
                    Debug.Log("No viable nodes");
                    return;
                }
            }
            RotateTowards(targetNode);
            MoveTowards(targetNode);
        }
	}
    bool ValidTarget(Vector3 target) {
        return (!Physics.Linecast(transform.position, target, ~(1 << 8))) && (transform.position - target).magnitude > 1;
    }
    List<Vector3> GetViableNodes() {
        List<Vector3> viable = new List<Vector3>();
        foreach (Vector3 t in nodes) {
            if (ValidTarget(t)) {
                viable.Add(t);
            }
        }
        return viable;
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
        if (anglediff > MaxRotateAngle*Time.deltaTime) {
            anglediff = MaxRotateAngle * Time.deltaTime * -det;
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
            if (dir.magnitude < 0.5 || Vector3.Angle(dir, vel) > 90)
            {
                vel = vel - (vel * drag * Time.deltaTime);
            }
            vel = vel + new Vector3(dir.x, dir.y, 0) * Time.deltaTime * acceleration;
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
