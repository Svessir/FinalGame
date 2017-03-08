using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControl : MonoBehaviour {
	public float currentRadius = -5;
	//private float currentRadiusTwo = -5;
	public float speed = 1;
	public float coolDown = 100;
	private float length = 500;
	public GameObject subMarine;
	public bool animated = false;

	//public Vector3 two= new Vector3(1,1,1);

	Material echoMaterialInt;
	Material echoMaterialExt;
	Material echoMaterialEnem;

	AudioSource sonarSound;

	bool active;

	// Use this for initialization
	void Start () {

		active = currentRadius > 0;

		sonarSound = GetComponent<AudioSource> ();

		Renderer ourRenderer = GetComponentInChildren<Renderer> ();
		Renderer[] allRenderers = FindObjectsOfType<Renderer> ();

		echoMaterialInt = ourRenderer.materials[0];
		echoMaterialExt = ourRenderer.materials[1];
		echoMaterialEnem = ourRenderer.materials[2];

		echoMaterialInt.SetVector ("_Origin", subMarine.transform.position);
		echoMaterialExt.SetVector ("_Origin", subMarine.transform.position);
		echoMaterialEnem.SetVector ("_Origin", subMarine.transform.position);

		// replace objects that use these 3 materials with a reference to our material
		// this makes them look the same
		foreach (var currentRenderer in allRenderers) {
			// Dont mess with our own renderer
			if (Object.ReferenceEquals(currentRenderer, ourRenderer)) { continue; }

			//Debug.Log (currentRenderer.materials.Length);

			Material[] newMaterialArray = new Material[currentRenderer.materials.Length];

			for (int i = 0; i < currentRenderer.materials.Length; i++) {

				if (currentRenderer.materials[i].name == echoMaterialInt.name) {
					//Debug.Log ("Set a material interiour");
					newMaterialArray [i] = echoMaterialInt;
				}

				else if (currentRenderer.materials[i].name == echoMaterialExt.name) {
					//Debug.Log ("Set a material exteriour");
					newMaterialArray [i] = echoMaterialExt;
				} 

				else if (currentRenderer.materials[i].name == echoMaterialEnem.name) {
					//Debug.Log ("Set a material enemy");
					newMaterialArray [i] = echoMaterialEnem;
				}
			}

			if (newMaterialArray[0] != null) {
				currentRenderer.materials = newMaterialArray;
			}

		}
	}
	
	void FixedUpdate () {

		if (!active) {
			if (animated) {
				active = true;
			} else if (Input.GetKeyDown(KeyCode.Space)) {
				active = !active;
			} else {
				return;
			}
		}

		currentRadius += speed;
			
		if (currentRadius > coolDown + length) {
			sonarSound.Play();
			currentRadius = -5;
			echoMaterialInt.SetVector ("_Origin", subMarine.transform.position);
			echoMaterialExt.SetVector ("_Origin", subMarine.transform.position);
			echoMaterialEnem.SetVector ("_Origin", subMarine.transform.position);
			active = false;

		}

		echoMaterialInt.SetFloat("_Radius", currentRadius);
		echoMaterialExt.SetFloat("_Radius", currentRadius);
		echoMaterialEnem.SetFloat("_Radius", currentRadius);
	}
}
