﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectableBehavior : MonoBehaviour 
{
	[SerializeField]
	float movementSpeed = 3f;

	[SerializeField]
	float travelTime = 0.5f;

	private bool isCollected = false;
	public bool IsCollected {get{ return isCollected; }}

	void Start () {
		CollectorManager.Instance.RegisterCollectable (this);
	}

	void Update () {
	}

	public void Collect() 
	{
		isCollected = true;
		GetComponent<Collider> ().enabled = false;
	}
}
