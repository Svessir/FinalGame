using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCamera : MonoBehaviour {

	public FollowTarget currentCamera;

	public bool enter;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			currentCamera.offset.z = -55;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			currentCamera.offset.z = -35;
		}
	}
}
