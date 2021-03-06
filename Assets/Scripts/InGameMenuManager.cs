﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour {

	private bool inMenu = false;
	private bool closingMenu = false;

	public Transform wholeMenu;
	public Transform beginning;
	public Transform checkpoint;
	public Transform quit;

	public mouseIsOver newGameMouse;
	public mouseIsOver retryMouse;  
	public mouseIsOver quitMouse;   

	public int selectedMenuItem = 1;

	public float outMoveDistamce = 0.1f;
	public DeathManager player;
	private Movement inputManager;

	void Start () {
		player = FindObjectOfType<DeathManager> ();
		inputManager = FindObjectOfType<Movement> ();
		inMenu = false;
	}

	public void StartMenu() {
		Time.timeScale = 0;
		inMenu = true;
		closingMenu = false;
	}

	public void EndMenu() {
		Time.timeScale = 1;
		closingMenu = true;
	}
	
	void Update () {
		if (!inMenu) {
			
			return;
		}
	
		Vector3 wholeMenuPos = wholeMenu.localPosition;
		if (closingMenu) {
			wholeMenuPos.z = (wholeMenuPos.z * 5 + 2710) / 6;
			wholeMenu.localPosition = wholeMenuPos;
			return;
		} else {
			wholeMenuPos.z = (wholeMenuPos.z * 7 + 2360) / 8;
			wholeMenu.localPosition = wholeMenuPos;
		}


		if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) {
			selectedMenuItem -= 1;
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
			selectedMenuItem += 1;
		}

		if (selectedMenuItem < 0) {
			selectedMenuItem = 2;
		}else if (selectedMenuItem > 2) {
			selectedMenuItem = 0;
		}


		if (newGameMouse.isSelected) {
			selectedMenuItem = 0;
		}
		if (retryMouse.isSelected) {
			selectedMenuItem = 1;
		}
		if (quitMouse.isSelected) {
			selectedMenuItem = 2;
		}


		if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) && (newGameMouse.isSelected || retryMouse.isSelected || quitMouse.isSelected)  ) {
			switch (selectedMenuItem)
			{
			case 0:
				Time.timeScale = 1;
				SceneManager.LoadScene("Opening");
				break;
			case 1:
				print ("Case 1");
				player.TakeDamage (9000);
				inputManager.ToggleMenu ();
				break;
			case 2:
				print("Should quit");
				Application.Quit();
				break;

			default:
				print("This menu item does not exist");
				break;
			}
		}




		Vector3 beginningPos = beginning.localPosition;
		Vector3 checkpointPos = checkpoint.localPosition;
		Vector3 quitPos = quit.localPosition;

		if (selectedMenuItem == 0) {
			beginningPos.z = outMoveDistamce;
			beginning.localPosition = beginningPos;
		} else {
			beginningPos.z = 0;
			beginning.localPosition = beginningPos;
		}

		if (selectedMenuItem == 1) {
			checkpointPos.z = outMoveDistamce;
			checkpoint.localPosition = checkpointPos;
		} else {
			checkpointPos.z = 0;
			checkpoint.localPosition = checkpointPos;
		}

		if (selectedMenuItem == 2) {
			quitPos.z = outMoveDistamce;
			quit.localPosition = quitPos;
		} else {
			quitPos.z = 0;
			quit.localPosition = quitPos;
		}
	}
}
