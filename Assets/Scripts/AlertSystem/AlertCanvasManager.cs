using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCanvasManager : MonoBehaviour {

	[SerializeField]
	private GameObject playerGameObject;

	[SerializeField]
	private float maximumDisplayRange = 20.0f;

	[SerializeField]
	private AlertUIElement alertUIPrefab;

	private static List<GameObject> uiElements; 

	private static AlertCanvasManager instance;

	public static AlertCanvasManager Instance 
	{ 
		get
		{ 
			return instance;
		}
	}

	public static void RegisterAlertable(IAlertable alertable) 
	{
		if (alertable != null && instance != null) {
			instance.Register (alertable);
		}
	}

	void Awake() 
	{
		instance = this;
	}

	private void Register(IAlertable alertable)
	{
		if (alertUIPrefab != null) 
		{
			AlertUIElement ui = Instantiate<AlertUIElement>(alertUIPrefab);
			ui.transform.SetParent (transform, false);
			ui.playerGameObject = playerGameObject;
			ui.trackedAlertable = alertable;
		}
	}
}
