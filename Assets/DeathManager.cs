using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour, IDeathable {

	public event DeathAction BeforeDeathEvent;
	public event DeathAction DeathEvent;

	public void TakeDamage (float damage)
	{
		if (BeforeDeathEvent != null) {
			BeforeDeathEvent ();
		}
		if (DeathEvent != null)
			DeathEvent ();
	}
}
