using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCanvasManager : MonoBehaviour 
{
	[SerializeField]
	private Text counterText;

	[SerializeField]
	private GameObject collectableFloat;

	[SerializeField]
	private Vector3 collectableFloatTravelVector;

	[SerializeField]
	private float animationTime = 1.0f;

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

	void OnCollected(CollectableBehavior collected) 
	{
		UpdateText ();
		StartCoroutine (CollectableFloatMovement(collected));
	}

	void OnCollectableRegistered()
	{
		UpdateText ();
	}

	void UpdateText() 
	{
		counterText.text = CollectorManager.Instance.CollectablesFound + "/" + CollectorManager.Instance.TotalNumberOfCollectables;
	}

	IEnumerator CollectableFloatMovement(CollectableBehavior collectable) 
	{
		collectableFloat.SetActive (true);
		Vector3 startPosition = Camera.main.WorldToScreenPoint (collectable.transform.position);
		Vector3 endPosition = startPosition + collectableFloatTravelVector;
		Vector3 currentPosition = startPosition;
		float start_time = Time.time;
		float end_time = start_time + animationTime;

		while(!currentPosition.Equals(endPosition))
		{
			float t = (Time.time - start_time) / (end_time - start_time);
			currentPosition = Vector3.Lerp (startPosition, endPosition, t);
			collectableFloat.transform.position = currentPosition;
			yield return new WaitForEndOfFrame ();
		}
		collectableFloat.SetActive (false);
		yield return null;
	}

	void Update () {
		
	}
}
