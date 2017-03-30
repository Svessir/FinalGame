using System.Collections;
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

	public int selectedMenuItem = 1;

	public float outMoveDistamce = 0.1f;
	public DeathManager player;
	private Movement inputManager;

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
		if (!inMenu) {
			
			return;
		}
	
		Vector3 wholeMenuPos = wholeMenu.localPosition;
		if (closingMenu) {
			wholeMenuPos.z = (wholeMenuPos.z * 5 + 2650) / 6;
			wholeMenu.localPosition = wholeMenuPos;
			return;
		} else {
			wholeMenuPos.z = (wholeMenuPos.z * 7 + 2360) / 8;
			wholeMenu.localPosition = wholeMenuPos;
		}


		if (Input.GetKeyDown(KeyCode.W)) {
			selectedMenuItem -= 1;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			selectedMenuItem += 1;
		}

		if (selectedMenuItem < 0) {
			selectedMenuItem = 2;
		}else if (selectedMenuItem > 2) {
			selectedMenuItem = 0;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
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
				UnityEditor.EditorApplication.isPlaying = false;
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
