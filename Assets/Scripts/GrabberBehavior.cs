using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabberBehavior : MonoBehaviour 
{
	[SerializeField]
	private Transform grabberForwardTransform;

	[SerializeField]
	private GrabbedHingeSettings grabbedHingeSettings;

	[SerializeField]
	private KeyCode grabKey;

	[SerializeField]
	private float tractorBeamLength = 1f;

	[SerializeField]
	private float distanceGromGrabber = 1f;

	[SerializeField]
	private float pullSpeed = 1f;

	private Rigidbody grabberRigidbody;

	private GrabableBehavior currentlyGrabbed;
	private bool isGrabKeyPressed = false;

	void Awake() 
	{
		grabberRigidbody = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		isGrabKeyPressed = Input.GetKeyDown (grabKey);
		if (currentlyGrabbed != null)
			WhileGrabbedUpdate (); 
		else
			WhileEmptyUpdate();
	}

	void FixedUpdate()
	{
	}

	void WhileGrabbedUpdate()
	{
		if (isGrabKeyPressed || IsObscured()) 
		{
			Drop ();
		}
	}

	void WhileEmptyUpdate()
	{
		if (isGrabKeyPressed) 
		{
			currentlyGrabbed = GetGrabable ();

			if (currentlyGrabbed != null) 
			{
				currentlyGrabbed.Grab ();
				StartCoroutine (PullGrabableTowardsMe ());
			}
		}
	}

	private GrabableBehavior GetGrabable()
	{
		GrabableBehavior grabbed = null;
		RaycastHit hit;

		if (Physics.Raycast (grabberForwardTransform.position, grabberForwardTransform.forward, out hit, tractorBeamLength)) 
		{
			grabbed = hit.collider.gameObject.GetComponent<GrabableBehavior> ();
		}
		return grabbed;
	}

	private IEnumerator PullGrabableTowardsMe()
	{
		Vector3 between = (transform.position - currentlyGrabbed.transform.position);
		while (between.magnitude > distanceGromGrabber) 
		{
			if (currentlyGrabbed == null)
				yield return null;
			else if (currentlyGrabbed == null)
				yield return null;

			Vector3 pos = currentlyGrabbed.transform.position;
			currentlyGrabbed.transform.position = new Vector3 (transform.position.x, pos.y, pos.z);
			Vector3 pullVector = grabberForwardTransform.forward;
			Vector3 betweenNormalized = between.normalized;
			currentlyGrabbed.transform.position -= pullVector * pullSpeed * Time.deltaTime;
			yield return new WaitForEndOfFrame ();
			between = (transform.position - currentlyGrabbed.transform.position);
		}
		currentlyGrabbed.SetHinges (grabbedHingeSettings, grabberRigidbody);
		yield return null;
	}

	private bool IsObscured()
	{
		RaycastHit hit;
		Vector3 between = (currentlyGrabbed.transform.position - transform.position);

		if (Physics.Raycast (grabberForwardTransform.position, between.normalized, out hit, between.magnitude)) 
		{
			return hit.collider.gameObject != currentlyGrabbed.gameObject;
		}
		
		return false;
	}

	private void Drop() 
	{
		currentlyGrabbed.Drop ();
		currentlyGrabbed = null;
	}
}
