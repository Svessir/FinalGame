using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GetComponent<Renderer>());
	}
	
}
