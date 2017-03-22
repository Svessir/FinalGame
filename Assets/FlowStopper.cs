using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStopper : MonoBehaviour {

	public Movement submarine;
	public GameObject AirPocket;
    public GameObject SuctionThing;
    public ParticleSystem particleFlow;
	public ParticleSystem particleFlow2;
	private float lockDownTimer;
	private bool locked;

	void OnTriggerEnter(Collider other) {
		print ("Trigger");
		if (other.transform.tag == "BockerStone")
		{
			print ("Should be blocked");

			particleFlow.Stop();
			particleFlow2.Stop();
			var part1 = particleFlow.main;
			var part2 = particleFlow2.main;

			part1.gravityModifier = -0.5f;
			part2.gravityModifier = -0.5f;

			submarine.inAir = false;
			AirPocket.SetActive (false);
            SuctionThing.SetActive(false);

		}
	}

	void OnTriggerStay(Collider other) {
		if (locked) {
			
		}
		else if (lockDownTimer < 2 && other.transform.tag == "BockerStone") {
			lockDownTimer += Time.deltaTime;
		}
		else if (other.transform.tag == "BockerStone") {
			locked = true;
			other.attachedRigidbody.isKinematic = true;
			Destroy (this);
		}


	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "BockerStone")
		{

			particleFlow.Play();
			particleFlow2.Play();
			var part1 = particleFlow.main;
			var part2 = particleFlow2.main;
			part1.gravityModifier = 1;
			part2.gravityModifier = 1;

			//submarine.inAir = false;
			AirPocket.SetActive (true);
            SuctionThing.SetActive(true);
        }
	}

}
