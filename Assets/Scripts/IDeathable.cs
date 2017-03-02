using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DeathAction();

public interface IDeathable
{
	event DeathAction DeathEvent;
}
