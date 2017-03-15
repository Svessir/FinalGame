using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FlashlightToggleAction(bool isOn);

public class PointToLight : MonoBehaviour {

	public GameObject flashLight;
	public bool animated = false;
	//public GameObject MousePointer;
	private float lightDepth;

	public static event FlashlightToggleAction FlashlightToggleEvent;

	void Update () {
		
		if (animated) {
			return;
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			flashLight.SetActive (!flashLight.activeSelf);

			if (FlashlightToggleEvent != null)
				FlashlightToggleEvent (flashLight.activeSelf);
		}

		if (!flashLight.activeSelf) {
			return;
		}

		Vector3 v3 = Input.mousePosition;

		lightDepth = - Camera.main.transform.position.z + flashLight.transform.parent.position.z + 1;


		v3.z = lightDepth;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		//MousePointer.transform.position = v3;

		v3 = v3 - flashLight.transform.parent.position;
		flashLight.transform.localRotation = Quaternion.LookRotation (v3);

	}
}
