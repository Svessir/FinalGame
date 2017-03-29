using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAlertable : MonoBehaviour, IAlertable {

	[SerializeField]
	private Renderer m_renderer;

	public event DestroyAction DestroyEvent;

	public Vector3 WorldPosition {
		get {
			return gameObject.transform.position;
		}
	}

	public AlertStatus AlertStatus {
		get {
			return AlertStatus.WARNING;
		}
	}

	public bool IsVisible {
		get {
			return m_renderer != null ? m_renderer.isVisible : false;
		}
	}
		

	// Use this for initialization
	void Start () {
		AlertCanvasManager.RegisterAlertable (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		if (DestroyEvent != null)
			DestroyEvent ();
	}
}
