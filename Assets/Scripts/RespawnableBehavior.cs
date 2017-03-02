using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RespawnableBehavior : MonoBehaviour {

	public abstract void Respawn (Vector3 respawnLocation);
}
