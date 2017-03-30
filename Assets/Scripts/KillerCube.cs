using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCube : MonoBehaviour {
	
	void OnCollisionEnter(Collision other)
	{
		IDeathable deathableBehavior = other.gameObject.GetComponent<IDeathable> ();
		if (deathableBehavior != null) {
			deathableBehavior.TakeDamage (9000);
		}
	}
}
