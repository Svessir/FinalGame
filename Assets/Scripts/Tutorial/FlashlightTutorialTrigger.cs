using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTutorialTrigger : TutorialTrigger {

	[SerializeField]
	PointToLight flashlight;

	protected override void OnPlayerEnter ()
	{
		if (flashlight != null && flashlight.IsOn)
			Destroy (gameObject);
		else
			PointToLight.FlashlightToggleEvent += OnFlashlightToggle;
	}

	protected override void OnPlayerExit ()
	{
		PointToLight.FlashlightToggleEvent -= OnFlashlightToggle;
	}

	private void OnFlashlightToggle(bool isOn) 
	{
		PointToLight.FlashlightToggleEvent -= OnFlashlightToggle;
		Destroy (gameObject);
	}
}
