using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialTrigger : MonoBehaviour {

	[SerializeField]
	protected TutorialText tutorialText;

	[SerializeField]
	protected string instruction;

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag.Equals ("Player")) 
		{
			tutorialText.SetText (instruction);
			OnPlayerEnter ();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Equals ("Player")) 
		{
			tutorialText.RemoveText (instruction);
			OnPlayerExit ();
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals ("Player") && tutorialText.IsEmpty) 
		{
			tutorialText.SetText (instruction);
		}
	}

	void OnDestroy()
	{
		tutorialText.RemoveText (instruction);
	}

	protected abstract void OnPlayerEnter ();

	protected abstract void OnPlayerExit ();
}
