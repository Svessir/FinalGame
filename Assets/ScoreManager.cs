using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

	[SerializeField]
	float waitForSeconds = 5f;

	[SerializeField]
	float fadeInTime = 1f;

	[SerializeField]
	Text counterText;

	[SerializeField]
	RawImage crystal;

	void Awake() {
		counterText.text = CollectedCounter.numberCollected + " out of " + CollectedCounter.totalNumber;
		StartCoroutine (FadeIn());
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeIn() {
		Color textColor = counterText.color;
		Color crystalColor = crystal.color;
		counterText.color = new Color (textColor.r, textColor.g, textColor.b, 0.0f);
		crystal.color = new Color (crystalColor.r, crystalColor.g, crystalColor.b, 0.0f);
		yield return new WaitForSeconds (waitForSeconds);
		Color textStartColor = counterText.color;
		Color crystalStartColor = crystal.color;
		float startTime = Time.time;
		float endTime = startTime + fadeInTime;
		float t = 0;
		while (t < 1) 
		{
			t = (Time.time - startTime) / (endTime - startTime);
			crystal.color = Color.Lerp (crystalStartColor, crystalColor, t);
			counterText.color = Color.Lerp (textStartColor, textColor, t);
			yield return new WaitForEndOfFrame ();
		}
		yield return null;
	}
}
