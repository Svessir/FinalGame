using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float maxSpeed = 10;
    public float acceleration = 2;
    public float drag = 1;
    public float gravity = 10;

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
        if (PlayerInLineOfSight())
        {
            RotateTowardsPlayer();
            MoveTowardsPlayer();
        }
        else {
            Move(Vector2.zero);
        }
	}

    bool PlayerInLineOfSight()
    {
        Vector3 toPlayer = player.transform.position - eye;
        RaycastHit hitinfo;
        Physics.Raycast(eye, toPlayer,out hitinfo,(toPlayer).magnitude, ~(1 << 8));
        if (hitinfo.collider != null) {
            return hitinfo.collider.gameObject.transform.tag == "Player";
        }
        return false;
    }
    void RotateTowardsPlayer() {
        Vector3 toPlayer = player.transform.position - transform.position;
        float angle = Vector3.Angle(Vector3.right, toPlayer);
        angle *= Mathf.Sign(toPlayer.y);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void MoveTowardsNode(Vector3 nodePos) {
        
    }

    void MoveTowardsPlayer() {
        Vector3 toPlayer = player.transform.position - transform.position;
        Move(toPlayer);
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
