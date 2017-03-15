using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStopper : MonoBehaviour {

	public Movement submarine;
	public GameObject AirPocket;
	public ParticleSystem particleFlow;
	public ParticleSystem particleFlow2;

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "BockerStone")
		{
			particleFlow.Stop();
			particleFlow2.Stop();
			submarine.inAir = false;
			AirPocket.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "BockerStone")
		{
			particleFlow.Play();
			particleFlow2.Play();
			//submarine.inAir = false;
			AirPocket.SetActive (true);
		}
	}

}
