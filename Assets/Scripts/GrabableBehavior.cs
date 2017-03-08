using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabableBehavior : MonoBehaviour 
{
	[SerializeField]
	float grabbedMass = 0.1f;

	private HingeJoint grabableHingeJoint;
	private Rigidbody grabableRigidbody;
	private float originalMass;

	void Awake () {
		grabableRigidbody = GetComponent<Rigidbody> ();
		originalMass = grabableRigidbody.mass;
	}

	void Update () {
		
	}

	public void Grab() 
	{
		grabableRigidbody.useGravity = false;
		grabableRigidbody.mass = grabbedMass;
	}

	public void Drop()
	{
		grabableRigidbody.mass = originalMass;
		grabableRigidbody.useGravity = true;
		Destroy (grabableHingeJoint);
		grabableHingeJoint = null;
	}

	public void SetHinges(GrabbedHingeSettings hingeSettings, Rigidbody grabberRigidbody) 
	{
		grabableHingeJoint = gameObject.AddComponent<HingeJoint> ();
		grabableHingeJoint.axis = hingeSettings.axis;
		grabableHingeJoint.useLimits = true;
		JointLimits limits = grabableHingeJoint.limits;
		limits.min = hingeSettings.minLimit;
		limits.max = hingeSettings.maxLimit;
		grabableHingeJoint.limits = limits;
		grabableHingeJoint.connectedBody = grabberRigidbody;
	}
}

[Serializable]
public class GrabbedHingeSettings
{
	public Vector3 axis;

	public float minLimit;

	public float maxLimit;
}
