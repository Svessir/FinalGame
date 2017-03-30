using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSoundHandler : RespawnableBehavior {

    public AudioSource audio;

    private float lastBump;

    private float deathTime;

    private Rigidbody rb;
    private Vector3 vel;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastBump = Time.time;
        deathTime = Time.time;
    }

    private void FixedUpdate() {
        vel = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        audio.volume = Vector3.Dot(normal, -vel)/10;
        StartCoroutine(PlayCrashSound());
    }

    IEnumerator PlayCrashSound()
    {
        yield return null;
        if(Time.time - deathTime > 0.5f)
        {
            if(Time.time - lastBump > 1)
            {
                audio.Play();
                lastBump = Time.time;
            }
            
        }
    }

    public override void Respawn(Vector3 checkpointLocation)
    {
        deathTime = Time.time;
    }
}
