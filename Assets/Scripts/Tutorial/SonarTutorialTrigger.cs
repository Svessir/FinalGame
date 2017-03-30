using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTutorialTrigger : TutorialTrigger 
{
	protected override void OnPlayerEnter ()
	{
		ShaderControl.SonarEvent += OnSonar;
	}

	protected override void OnPlayerExit ()
	{
		ShaderControl.SonarEvent -= OnSonar;
	}

	void OnDestroy() 
	{
		ShaderControl.SonarEvent -= OnSonar;
	}

	private void OnSonar() 
	{
		//Destroy (gameObject);
	}
}
