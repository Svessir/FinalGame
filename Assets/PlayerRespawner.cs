using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : RespawnableBehavior {

    public AudioSource audio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Respawn (Vector3 checkpointLocation)
	{
        audio.Play();
		transform.position = checkpointLocation;
        StartCoroutine(stopPlaying());
	}

    IEnumerator stopPlaying()
    {
        yield return new WaitForSeconds(1);
        audio.Stop();
    }
}
