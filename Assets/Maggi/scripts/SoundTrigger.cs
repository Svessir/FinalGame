﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : RespawnableBehavior {

    public AudioSource aud;

    private void OnTriggerEnter(Collider other)
    {
        aud.Play();
    }

    public override void Respawn(Vector3 checkpointLocation)
    {
        aud.Stop();
    }
}
