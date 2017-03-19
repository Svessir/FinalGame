using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabableBehavior : MonoBehaviour 
{
	[SerializeField]
	float grabbedMass = 0.1f;

	[SerializeField]
	private float requiredDistance;

	public float RequiredDistance { get{ return requiredDistance; } }
	public Vector3 GrabbedPoint { get{ return transform.TransformPoint(anchor); }}

	private HingeJoint grabableHingeJoint;
	private Rigidbody grabableRigidbody;
	private float originalMass;
	private Vector3 anchor;

	void Awake () {
		grabableRigidbody = GetComponent<Rigidbody> ();
		originalMass = grabableRigidbody.mass;
	}

	void Update () {
		
	}

	public void Grab() 
	{
		grabableRigidbody.mass = grabbedMass;
        grabableRigidbody.angularDrag = 3;
        grabableRigidbody.drag = 0.5f;
	}

	public void Drop()
	{
		grabableRigidbody.useGravity = true;
		Destroy (grabableHingeJoint);
		grabableHingeJoint = null;
	}

	public void SetHinges(GrabbedHingeSettings hingeSettings, Rigidbody grabberRigidbody) 
	{
		grabableHingeJoint = gameObject.AddComponent<HingeJoint> ();
		grabableHingeJoint.anchor = anchor;
		grabableHingeJoint.axis = hingeSettings.axis;
		grabableHingeJoint.useLimits = true;
		JointLimits limits = grabableHingeJoint.limits;
		limits.min = hingeSettings.minLimit;
		limits.max = hingeSettings.maxLimit;
		grabableHingeJoint.limits = limits;
		grabableHingeJoint.connectedBody = grabberRigidbody;
	}


	public void SetWorldSpaceAnchor(Vector3 anchor)
	{
		this.anchor = transform.InverseTransformPoint(anchor);
	}
}

[Serializable]
public class GrabbedHingeSettings
{
	public Vector3 axis;

	public float minLimit;

	public float maxLimit;
}
