using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RespawnAction(Vector3 position);

public class RespawnManager : MonoBehaviour {

	[SerializeField]
	private CheckPointManager checkpointManager;

	private IDeathable DeathableBehavior;

	public static RespawnAction PlayerRespawnEvent;

	void Awake () 
	{
		GetDeathable ();
		Subscribe ();
	}

	void OnEnable()
	{
		Subscribe ();
	}

	void OnDisable()
	{
		UnSubcribe ();
	}

	/**
	 * <summary>
	 * Loops through all components that have respawn logic
	 * and invokes that logic.
	 * </summary>
	 * 
	*/
	private void OnDeath() 
	{
		if (PlayerRespawnEvent != null)
			PlayerRespawnEvent (checkpointManager.CurrentCheckpoint.location);
	}

	private void Subscribe() 
	{
		if (DeathableBehavior != null)
			DeathableBehavior.DeathEvent += OnDeath;
	}

	private void UnSubcribe()
	{
		if (DeathableBehavior != null)
			DeathableBehavior.DeathEvent -= OnDeath;
	}

	private void GetDeathable() 
	{
		DeathableBehavior = GetComponent<IDeathable> ();
		if (DeathableBehavior == null)
			DeathableBehavior = GetComponentInChildren<IDeathable> ();
		if (DeathableBehavior == null)
			DeathableBehavior = GetComponentInParent<IDeathable> ();
	}
}
