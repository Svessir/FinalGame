﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SonarAction();

public class ShaderControl : MonoBehaviour {
	public float currentRadius = -5;
	public float speed = 45;
	public float coolDown = 12;

    private float timer = 0;
	private bool active;
	[HideInInspector]
	public bool inMenu = false;

	public float  CooldownRatio 
	{ 
		get 
		{
			return timer/coolDown;
		} 
	}

    private float length = 500;
	public GameObject subMarine;
	public bool animated = false;

	Material[] ourMaterials;
	private int numberOfMaterials;
    private EnemyAI[] fishes;
	AudioSource sonarSound;

	public static event SonarAction SonarEvent;

	// Use this for initialization
	void Start () {
        fishes = GameObject.FindObjectsOfType<EnemyAI>();
        if (length / speed > coolDown)
        {
            Debug.Log(length / speed);
            Debug.Log(coolDown);
            Debug.Log("cooldown in shadercontrol is too short, this will cause problems with hte AISonarDetection");
        }
		active = currentRadius > 0;

		sonarSound = GetComponent<AudioSource> ();

		Renderer ourRenderer = GetComponentInChildren<Renderer> ();
		Renderer[] allRenderers = FindObjectsOfType<Renderer> ();


		// Setup Material
		ourMaterials = ourRenderer.materials;
		numberOfMaterials = ourMaterials.Length;
		setMaterialCenter ();
		setMaterialRadius ();

		// Replace objects that use these 3 materials with a reference to our material
		// this makes them look the same
		foreach (var currentRenderer in allRenderers) {
			// Dont mess with our own renderer
			if (Object.ReferenceEquals(currentRenderer, ourRenderer)) { continue; }

			Material[] newMaterialArray = new Material[currentRenderer.materials.Length];

			for (int i = 0; i < currentRenderer.materials.Length; i++) {
				for (int j = 0; j < numberOfMaterials; j++) {
					if (currentRenderer.materials [i].name == ourMaterials [j].name) {
						newMaterialArray [i] = ourMaterials [j];
					} 
					//else {
						//newMaterialArray [i] = currentRenderer.materials [i];
					//}

				}
			}

			if (newMaterialArray[0] != null) {
				currentRenderer.materials = newMaterialArray;
			}
		}
	}

	
	void FixedUpdate () {

		if (!active || inMenu) {
			return;
		}

		currentRadius += speed*Time.fixedDeltaTime;
			
		if (currentRadius > length) {
			currentRadius = -5;
			active = false;

		}

		setMaterialRadius ();
	}


	void Update()
    {
		if (inMenu) {
			return;
		}
        timer -= Time.deltaTime;
        if (!active) {
			if (animated || (Input.GetKeyDown(KeyCode.Space) && timer <= 0)) {
                timer = coolDown;
				active = true;
                foreach (EnemyAI f in fishes) {
                    f.SonarActivated(speed);
                }
				setMaterialCenter ();
				sonarSound.Play();

				if (SonarEvent != null)
					SonarEvent ();
			}
        }
	}


	void setMaterialRadius() {
		for (int i = 0; i < numberOfMaterials; i++) {
			ourMaterials[i].SetFloat("_Radius", currentRadius);
		}
	}


	void setMaterialCenter() {
		for (int i = 0; i < numberOfMaterials; i++) {
			ourMaterials[i].SetVector ("_Origin", subMarine.transform.position);
		}
	}
}
