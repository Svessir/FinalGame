using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSubCenter : MonoBehaviour {

	public GameObject Sub;
	Renderer cliffRenderer;
	Material mainMaterial;
	Material sumMaterial;

	// Use this for initialization
	void Start () {
		cliffRenderer = GetComponentInChildren<Renderer> ();
		mainMaterial = cliffRenderer.materials [0];
		sumMaterial = cliffRenderer.materials [1];
	}
	
	// Update is called once per frame
	void Update () {
		mainMaterial.SetVector ("_Origin", Sub.transform.position);
		sumMaterial.SetVector ("_Origin", Sub.transform.position);

	}
}
