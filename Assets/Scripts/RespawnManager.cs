using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

	[SerializeField]
	private RespawnableBehavior[] respawnables;

	[SerializeField]
	private CheckPointManager checkpointManager;

	private IDeathable DeathableBehavior;

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
		foreach(var respawnable in respawnables)
			respawnable.Respawn(checkpointManager.CurrentCheckpoint.location);
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
			DeathableBehavior = GetComponentsInParent<IDeathable> ();
	}
}
