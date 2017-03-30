using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSoundHandler : RespawnableBehavior {

    public AudioSource audio;

    private float lastBump;

    private float deathTime;

    private void Start()
    {
        lastBump = Time.time;
        deathTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
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
