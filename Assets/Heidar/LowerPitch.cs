using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPitch : MonoBehaviour {
	public float goalPitch = 0.5f;
	public float speed = 0.001f;
	AudioSource song;

	// Use this for initialization
	void Start () {
		song = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (goalPitch < song.pitch) {
			song.pitch -= speed;
		} else {
			Debug.Log (song.pitch);
			song.pitch = goalPitch;
			Destroy (this);
		}

	}
}
