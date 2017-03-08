using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWormAI : MonoBehaviour {
    public float maxSpeed = 3;
    public float acceleration = 5;
    public float drag = 0.5f;
    public float gravity = 10;
    public float RotationRate = 90;
    public float AggressionDist = 10;
    public float AggressionTime = 1.5f;
    public float MinRecoveryAngle = 25;
    public float RecoveryTime = 0.5f;
    public GameObject restingPos;

    private float Timer = 0;
    private bool aggressive = true;
    private Vector3 eye;
    private Transform eyeTransform;
    private GameObject player;
    private Rigidbody rb;
    private bool inAir = false;
	// Use this for initialization
	void Start ()
    {
        Timer = AggressionTime;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                if (aggressive)
                {
                    Timer = RecoveryTime;
                }
                else
                {
                    Timer = AggressionTime;
                }
                aggressive = !aggressive;
            }
            if (!aggressive && MinRecoveryAngle < Vector3.Angle(transform.right, player.transform.position - eye))
            {
                aggressive = true;
                Timer = AggressionTime;
            }
            if (aggressive)
            {
                RotateTowards(player.transform.position);
                MoveTowards(player.transform.position);
            }
            else
            {
                MoveAwayFrom(player.transform.position);
                RotateTowards(player.transform.position);
            }
        }
        else {
            if (Vector3.Distance(restingPos.transform.position, transform.position) > 1)
            {
                MoveTowards(restingPos.transform.position);
            }
            aggressive = true;
            Timer = AggressionTime;
        }
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

    void MoveAwayFrom(Vector3 nodePos) {
        Vector3 toTarget = transform.position - nodePos;
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
            dir.Normalize();
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
