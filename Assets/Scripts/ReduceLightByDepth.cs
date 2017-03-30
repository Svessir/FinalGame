using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceLightByDepth : MonoBehaviour {

	public GameObject ship;
	Light selfLight;
	// Use this for initialization
	void Start () {
		selfLight = GetComponent<Light> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (ship.transform.position.y < -15) {
			selfLight.intensity = 1 - ((ship.transform.position.y + 15) / -80) ;
		} else {
			selfLight.intensity = 1;
		}
		
	}
}
