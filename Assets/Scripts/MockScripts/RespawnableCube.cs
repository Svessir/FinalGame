using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableCube : RespawnableBehavior {

	private Vector3 myCheckpointLocation;

	void Awake () 
	{
		myCheckpointLocation = transform.position;
	}

	void Update () 
	{
		transform.position += Vector3.right * Time.deltaTime;
	}

	#region implemented abstract members of RespawnableBehavior

	public override void Respawn (Vector3 checkpointLocation)
	{
		transform.position = myCheckpointLocation;
	}

	#endregion

	protected override void OnCheckpointReached(CheckPoint checkpoint) 
	{
		myCheckpointLocation = transform.position;
	}
}
