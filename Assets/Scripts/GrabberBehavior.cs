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
	private float shootSpeed = 1f;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private LayerMask raycastIgnore;

	private Rigidbody grabberRigidbody;

	private GrabableBehavior currentlyGrabbed;
	private bool isGrabKeyPressed = false;
	private bool isGrabbing = false;
	private Quaternion originalRotation;

	void Awake() 
	{
		raycastIgnore.value = ~raycastIgnore.value;
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

	void WhileGrabbedUpdate()
	{
		if (isGrabKeyPressed || IsObscured ()) {
			Drop ();
		} else {
			lineRenderer.SetPosition (0, grabberForwardTransform.position);
			lineRenderer.SetPosition (1, currentlyGrabbed.GrabbedPoint);
		}
	}

	void WhileEmptyUpdate()
	{
		if (isGrabKeyPressed && !isGrabbing) 
		{
			StartCoroutine (ExtendGrabber ());
		}
	}

	private IEnumerator ExtendGrabber()
	{
		isGrabbing = true;

		float distance = 0;

		RaycastHit hit;

		lineRenderer.enabled = true;

		Vector3 between = Vector3.zero;

		while (distance < tractorBeamLength) 
		{
			distance += shootSpeed * Time.deltaTime;

			between = grabberForwardTransform.forward * distance;

			lineRenderer.SetPosition (0, grabberForwardTransform.position);
			lineRenderer.SetPosition (1, grabberForwardTransform.position + between);

			if (Physics.Raycast (grabberForwardTransform.position, grabberForwardTransform.forward, out hit, distance, raycastIgnore.value)) 
			{
				currentlyGrabbed = hit.collider.gameObject.GetComponent<GrabableBehavior> ();

				if (currentlyGrabbed != null) {
					currentlyGrabbed.SetWorldSpaceAnchor (hit.point);
					currentlyGrabbed.SetHinges (grabbedHingeSettings, grabberRigidbody);
					currentlyGrabbed.Grab ();
				}
				break;
			}

			yield return new WaitForEndOfFrame ();
		}

		if (currentlyGrabbed == null) 
		{
			yield return StartCoroutine (Retract(between));
		}

		isGrabbing = false;
	}

	private IEnumerator Retract(Vector3 between)
	{
		isGrabbing = true;
		lineRenderer.enabled = true;
		float distance = between.magnitude;

		while (distance > 0) 
		{
			distance -= shootSpeed * Time.deltaTime;

			Vector3 between2 = between.normalized * distance;

			lineRenderer.SetPosition (0, grabberForwardTransform.position);
			lineRenderer.SetPosition (1, grabberForwardTransform.position + between2);

			yield return new WaitForEndOfFrame ();
		}
		isGrabbing = false;
		lineRenderer.enabled = false;
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

	private void Grab()
	{
		currentlyGrabbed.SetHinges (grabbedHingeSettings, grabberRigidbody);
		currentlyGrabbed.UseGravity (true);
	}

	private bool IsObscured()
	{
		RaycastHit hit;
		Vector3 between = (currentlyGrabbed.GrabbedPoint - grabberForwardTransform.position);

		if (Physics.Raycast (grabberForwardTransform.position, between.normalized, out hit, between.magnitude, raycastIgnore.value)) 
		{
			return hit.collider.gameObject != currentlyGrabbed.gameObject;
		}
		
		return false;
	}

	private void Drop() 
	{
		StartCoroutine (Retract((currentlyGrabbed.transform.position - grabberForwardTransform.position)));
		currentlyGrabbed.UseGravity (true);
		currentlyGrabbed.Drop ();
		currentlyGrabbed = null;
		grabberForwardTransform.rotation = originalRotation;
		grabberRigidbody.angularVelocity = Vector3.zero;
		grabberRigidbody.velocity = Vector3.zero;
	}
}
