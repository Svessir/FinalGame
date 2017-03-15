using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTutorialTrigger : TutorialTrigger {
	
	protected override void OnPlayerEnter ()
	{
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
