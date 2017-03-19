using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : RespawnableBehavior {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Respawn (Vector3 checkpointLocation)
	{
		transform.position = checkpointLocation;
	}
}
