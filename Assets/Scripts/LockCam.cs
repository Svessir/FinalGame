using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCam : MonoBehaviour {
    public GameObject Submarine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = Submarine.transform.position.x;
        pos.y = Submarine.transform.position.y;
        transform.position = pos;
    }
}
