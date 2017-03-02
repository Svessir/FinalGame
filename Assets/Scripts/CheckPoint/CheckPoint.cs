using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CheckPointActivatedAction();

public class CheckPoint : MonoBehaviour {

	[SerializeField]
	private Transform internalCheckpoint;

	public Vector3 location 
	{
		get
		{
			return internalCheckpoint.position;
		}
	}

	public event CheckPointActivatedAction CheckPointActivatedEvent;

	void Start () {
		
	}

	void Update () {
		
	}

	public void Activate()
	{
		if (CheckPointActivatedEvent != null)
			CheckPointActivatedEvent ();
	}
}
