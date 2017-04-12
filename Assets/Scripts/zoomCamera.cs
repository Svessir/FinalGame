using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCamera : MonoBehaviour {

	public FollowTarget currentCamera;
	public bool enter;

	public float distance = 65;
	private float defaultDistance;

	void Start() {
		defaultDistance = currentCamera.offset.z;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			currentCamera.offset.z = -distance;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			currentCamera.offset.z = defaultDistance;
		}
	}
}
