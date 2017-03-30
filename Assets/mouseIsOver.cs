using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseIsOver : MonoBehaviour {

	public bool isSelected;

	void OnMouseOver()
	{
		isSelected = true;
	}

	void OnMouseExit()
	{
		isSelected = false;
	}
}
