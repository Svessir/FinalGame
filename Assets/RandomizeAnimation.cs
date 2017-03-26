using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var ani = GetComponent<Animator>();
        ani.speed = Random.Range(2, 2.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
