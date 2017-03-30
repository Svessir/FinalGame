using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public Animator mainCamera;
	public Animator title;
	public GameObject titleObject;
	public GameObject Submarine;
	public GameObject TutorialTriggers;

	private bool started = false;

	// Use this for initialization
	void Start () {
		mainCamera.speed = 0;
		title.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (started) {
			Submarine.transform.localPosition = Vector3.zero;
			if (mainCamera.GetCurrentAnimatorStateInfo(0).IsName("Done")) {
				Destroy (mainCamera);
				//Destroy (title);
				Destroy (titleObject);
				TutorialTriggers.SetActive (true);
				print ("yas queen");
				Destroy (this);
			}
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
			started = true;
			Submarine.transform.localPosition = Vector3.zero;
			mainCamera.speed = 1;
			title.speed = 1;
		}
	}
}
