using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSoundHandler : RespawnableBehavior {

    public AudioSource audio;

    private float deathTime;

    private void Start()
    {
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
            audio.Play();
        }
    }

    public override void Respawn(Vector3 checkpointLocation)
    {
        deathTime = Time.time;
    }
}
