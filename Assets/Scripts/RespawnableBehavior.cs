using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RespawnableBehavior : MonoBehaviour 
{
	public abstract void Respawn (Vector3 checkpointLocation);

	void OnEnable() 
	{
		Subscribe ();
	}

	void OnDisable()
	{
		UnSubscribe ();
	}

	private void Subscribe()
	{
		CheckPointManager.CheckpointReachedEvent += OnCheckpointReached;
		RespawnManager.PlayerRespawnEvent += Respawn;
	}

	private void UnSubscribe()
	{
		CheckPointManager.CheckpointReachedEvent -= OnCheckpointReached;
		RespawnManager.PlayerRespawnEvent -= Respawn;
	}

	/**
	 * <summary>
	 * Called when the checkpoint manager has reached a checkpoint.
	 * Override this method to store any variables that need saving for that checkpoint.
	 * </summary>
	 * 
	 * */
	protected virtual void OnCheckpointReached(CheckPoint checkpoint) 
	{
	}
}
