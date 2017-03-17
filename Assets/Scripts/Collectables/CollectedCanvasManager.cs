using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCanvasManager : MonoBehaviour 
{
	[SerializeField]
	private Text counterText;

	void OnEnable() 
	{
		CollectorManager.CollectedEvent += OnCollected;
		CollectorManager.RegisterEvent += OnCollectableRegistered;
	}

	void OnDisable()
	{
		CollectorManager.CollectedEvent -= OnCollected;
		CollectorManager.RegisterEvent -= OnCollectableRegistered;
	}

	void OnCollected() 
	{
		UpdateText ();
	}

	void OnCollectableRegistered()
	{
		UpdateText ();
	}

	void UpdateText() 
	{
		counterText.text = CollectorManager.Instance.CollectablesFound + "/" + CollectorManager.Instance.TotalNumberOfCollectables;
	}

	void Update () {
		
	}
}
