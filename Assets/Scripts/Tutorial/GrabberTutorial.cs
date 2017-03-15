using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberTutorial : TutorialTrigger 
{
	protected override void OnPlayerEnter ()
	{
		GrabberBehavior.GrabEvent += OnGrab;
	}

	protected override void OnPlayerExit ()
	{
		GrabberBehavior.GrabEvent -= OnGrab;
	}

	private void OnGrab() 
	{
		GrabberBehavior.GrabEvent -= OnGrab;
		Destroy (gameObject);
	}
}
