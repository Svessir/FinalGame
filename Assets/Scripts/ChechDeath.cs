﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.layer == 8) {
			Debug.Log ("You died");
		}

	}
}
