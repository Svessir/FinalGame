using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCanvasManager : MonoBehaviour 
{
	[SerializeField]
	private Text counterText;

	[SerializeField]
	private RawImage collectableImage;

	[SerializeField]
	private GameObject collectableFloat;

    [SerializeField]
    private RawImage collectableFloatImage;

    [SerializeField]
	private Vector3 collectableFloatTravelVector;

	[SerializeField]
	private float animationTime = 1.0f;

	[SerializeField]
	private float fadeOutTime = 5f;

	void Awake() 
	{
		collectableImage.color = new Color(collectableImage.color.r, collectableImage.color.g, collectableImage.color.b, 0.0f);
		counterText.color = new Color(counterText.color.r, counterText.color.g, counterText.color.b, 0.0f);
	}

	void OnEnable() 
	{
		CollectorManager.CollectedEvent += OnCollected;
		CollectorManager.RegisterEvent += OnCollectableRegistered;
	}

	void OnDisable()
	{
		CollectorManager.CollectedEvent -= OnCollected;
		CollectorManager.RegisterEvent -= OnCollectableRegistered;
	}

	void OnCollected(CollectableBehavior collected) 
	{
		UpdateText ();
		StartCoroutine (CollectableFloatMovement(collected));
	}

	void OnCollectableRegistered()
	{
		UpdateText ();
	}

	void UpdateText() 
	{
		counterText.text = CollectorManager.Instance.CollectablesFound.ToString();
	}

	IEnumerator CollectableFloatMovement(CollectableBehavior collectable) 
	{
		collectableImage.color = new Color(collectableImage.color.r, collectableImage.color.g, collectableImage.color.b, 1.0f);
		counterText.color = new Color(counterText.color.r, counterText.color.g, counterText.color.b, 1.0f);
		collectableFloat.SetActive (true);
		Vector3 startPosition = Camera.main.WorldToScreenPoint (collectable.transform.position);
		Vector3 endPosition = startPosition + collectableFloatTravelVector;
		Vector3 currentPosition = startPosition;
		float start_time = Time.time;
		float end_time = start_time + animationTime;

        Color floatImageStartColor = collectableImage.color;
        Color floatImageEndColor = new Color(counterText.color.r, counterText.color.g, counterText.color.b, 0.0f);

        while (!currentPosition.Equals(endPosition))
		{
			float t = (Time.time - start_time) / (end_time - start_time);
			currentPosition = Vector3.Lerp (startPosition, endPosition, t);
			collectableFloat.transform.position = currentPosition;
            float remaining = (Time.time - start_time);
            if (remaining <= 1)
            {
                collectableFloatImage.color = Color.Lerp(floatImageStartColor, floatImageEndColor, remaining);
            }
            yield return new WaitForEndOfFrame ();
		}
		collectableFloat.SetActive (false);

		float startTime = Time.time;
		float endTime = startTime + fadeOutTime;
		float t2 = 0;

		Color textStartColor = counterText.color;
		Color imageStartColor = collectableImage.color;

		Color textEndColor = new Color(collectableImage.color.r, collectableImage.color.g, collectableImage.color.b, 0.0f);
		Color imageEndColor = new Color(counterText.color.r, counterText.color.g, counterText.color.b, 0.0f);
		while (t2 <= 1) 
		{
			t2 = (Time.time - startTime) / (endTime - startTime);
			counterText.color = Color.Lerp (textStartColor, textEndColor, t2);
			collectableImage.color = Color.Lerp (imageStartColor, imageEndColor, t2);

            yield return new WaitForEndOfFrame ();
		}

		yield return null;
	}
}
