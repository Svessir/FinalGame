using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockDeathableRespawnable : RespawnableBehavior, IDeathable {

	public event DeathAction DeathEvent;

	void Update () {
		if (Input.GetKeyDown (KeyCode.O) && DeathEvent != null)
			DeathEvent ();
	}

	public override void Respawn (Vector3 respawnLocation)
	{
		transform.position = respawnLocation;
	}

	public void TakeDamage (float damage)
	{
		throw new System.NotImplementedException ();
	}
}
