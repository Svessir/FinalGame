using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CheckpointReachedAction(CheckPoint checkpoint);

[RequireComponent(typeof(Collider))]
class CheckPointManager : MonoBehaviour {

	[SerializeField]
	private CheckPoint currentCheckpoint;

	public event CheckpointReachedAction CheckpointReachedEvent;

	public CheckPoint CurrentCheckpoint 
	{
		get
		{
			return currentCheckpoint;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		CheckPoint checkpoint = other.gameObject.GetComponent<CheckPoint> ();

		if (checkpoint != null) 
		{
			Debug.Log ("CheckPoint Reached!");
			currentCheckpoint = checkpoint;
			currentCheckpoint.Activate ();

			if (CheckpointReachedEvent != null)
				CheckpointReachedEvent (currentCheckpoint);
		}
	}
}
