using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour, IDeathable {
	
	public event DeathAction DeathEvent;

	public void TakeDamage (float damage)
	{
		if (DeathEvent != null)
			DeathEvent ();
	}
}
