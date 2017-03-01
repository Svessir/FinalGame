using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float maxSpeed = 10;
    public float acceleration = 10;
    public float drag = 0.3f;


    private Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y).normalized;
        Move(dir);
	}

    void Move(Vector2 dir)
    {
        Vector3 vel = rb.velocity;
        vel = vel - vel * drag;
        vel = vel + new Vector3(dir.x,dir.y,0)* Time.deltaTime*acceleration;
        if (vel.magnitude > maxSpeed) {
            vel = vel.normalized * maxSpeed;
        }
        rb.velocity = vel;
    }
}
