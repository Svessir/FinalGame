using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

	[SerializeField]
	private Text tutorialText;

	void Start () 
	{
	}

	void Update () 
	{
	}

	public void SetText(string tutorialText) 
	{
		this.tutorialText.text = tutorialText;
	}

	public void RemoveText(string tutorialText)
	{
		if (this.tutorialText.text.Equals (tutorialText))
			this.tutorialText.text = "";
	}
}
