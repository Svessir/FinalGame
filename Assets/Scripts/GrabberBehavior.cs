﻿using System.Collections;
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

	[SerializeField]
	private LineRenderer lineRenderer;

	private Rigidbody grabberRigidbody;

	private GrabableBehavior currentlyGrabbed;
	private bool isGrabKeyPressed = false;
	private Quaternion originalRotation;

	void Awake() 
	{
		grabberRigidbody = GetComponent<Rigidbody> ();
		originalRotation = grabberForwardTransform.rotation;
		lineRenderer.enabled = false;
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
		if (isGrabKeyPressed || IsObscured ()) {
			Drop ();
		} else {
			lineRenderer.SetPosition (0, grabberForwardTransform.position);
			lineRenderer.SetPosition (1, currentlyGrabbed.transform.position);
		}
	}

	void WhileEmptyUpdate()
	{
		if (isGrabKeyPressed) 
		{
			currentlyGrabbed = GetGrabable ();

			if (currentlyGrabbed != null) 
			{
				lineRenderer.enabled = true;
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

			if (grabbed != null)
				grabbed.SetWorldSpaceAnchor (hit.point);
		}
		return grabbed;
	}

	private IEnumerator PullGrabableTowardsMe()
	{
		float distance = currentlyGrabbed.RequiredDistance + distanceGromGrabber;
		currentlyGrabbed.UseGravity (false);
		Vector3 between = (transform.position - currentlyGrabbed.transform.position);
		Vector3 test = new Vector3 (between.x, between.y);
		while (test.magnitude > distance) 
		{
			Debug.Log (test.magnitude);
			Vector3 pos = currentlyGrabbed.transform.position;
			//currentlyGrabbed.transform.position = new Vector3 (transform.position.x, pos.y, pos.z);
			Vector3 pullVector = grabberForwardTransform.forward;
			Vector3 betweenNormalized = between.normalized;
			currentlyGrabbed.transform.position -= pullVector * pullSpeed * Time.deltaTime;
			yield return new WaitForEndOfFrame ();

			if (currentlyGrabbed == null) {
				yield return null;
				break;
			}
			else {
				between = (transform.position - currentlyGrabbed.transform.position);
				test = new Vector3 (between.x, between.y);
			}
		}

		if (currentlyGrabbed != null) {
			currentlyGrabbed.SetHinges (grabbedHingeSettings, grabberRigidbody);
			currentlyGrabbed.UseGravity (true);
		}

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
		currentlyGrabbed.UseGravity (true);
		lineRenderer.enabled = false;
		currentlyGrabbed.Drop ();
		currentlyGrabbed = null;
		grabberForwardTransform.rotation = originalRotation;
		grabberRigidbody.angularVelocity = Vector3.zero;
		grabberRigidbody.velocity = Vector3.zero;
	}
}
