using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectableBehavior : MonoBehaviour 
{
	[SerializeField]
	float movementSpeed = 3f;

	[SerializeField]
	float travelTime = 0.5f;

	private bool isCollected = false;
	public bool IsCollected {get{ return isCollected; }}

	void Start () {
		CollectorManager.Instance.RegisterCollectable (this);
	}

	void Update () {
	}

	public void Collect() 
	{
		isCollected = true;
		StartCoroutine (CollectedMovement());
		GetComponent<Collider> ().enabled = false;
	}

	IEnumerator CollectedMovement() 
	{
		Debug.Log (Camera.main.WorldToScreenPoint (transform.position));
		Vector3 start = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 end = new Vector3(Screen.width/2.0f, Screen.height/2.0f, 5);
		Vector3 currentPosition = start;

		float startTime = Time.time;
		float endTime = startTime + travelTime;
		while (!currentPosition.Equals (end)) 
		{
			currentPosition = Vector3.Lerp (start, end, (Time.time - startTime)/(endTime - startTime));
			transform.position = Camera.main.ScreenToWorldPoint(currentPosition);
			yield return new WaitForEndOfFrame ();
		}
		yield return null;
	}
}
