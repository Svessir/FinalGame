using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeThingSection : MonoBehaviour {
    public float maxSpeed = 2;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
	}
}
