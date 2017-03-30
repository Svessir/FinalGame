using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonarMeterCanvasManager : MonoBehaviour {

	[SerializeField] 
	private ShaderControl sonarTrigger;

	[SerializeField]
	private Image meter;

	[SerializeField]
	private Color fullColor;

	[SerializeField]
	private Color emptyColor;

	private float maxWidth;
	private bool isAnimating = false;
	private bool isMissed = false;

	void Awake() 
	{
		maxWidth = meter.rectTransform.rect.width;
		meter.enabled = false;
		Subscribe ();
	}

	void OnEnable() {
		Subscribe ();
	}

	void Update()
	{
		if (isMissed && !isAnimating) {
			isMissed = false;
			StartCoroutine (SonarMeterUpdate ());
		}
	}

	void OnDestroy()
	{
		Unsubscribe ();
	}

	void OnDisable() {
		Unsubscribe ();
	}

	void Subscribe() 
	{
		ShaderControl.SonarEvent += OnSonar;
	}

	void Unsubscribe()
	{
		ShaderControl.SonarEvent -= OnSonar;
	}

	void OnSonar() 
	{
		if (!isAnimating)
			StartCoroutine (SonarMeterUpdate ());
		else
			isMissed = true;
	}

	IEnumerator SonarMeterUpdate() 
	{
		isAnimating = true;
		meter.enabled = true;
		float t = sonarTrigger.CooldownRatio;
		while (t > 0) 
		{
			t = sonarTrigger.CooldownRatio;
			meter.rectTransform.sizeDelta = new Vector2(t * maxWidth, meter.rectTransform.rect.height);
			meter.color = Color.Lerp (emptyColor, fullColor, t);
			yield return new WaitForEndOfFrame();
		} 
		meter.enabled = false;
		isAnimating = false;
	}
}
