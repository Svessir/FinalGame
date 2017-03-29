using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertUIElement : MonoBehaviour {

	[SerializeField]
	Text alertText;

	[SerializeField]
	private Color warningColor;

	[SerializeField]
	private Color dangerColor;

	[SerializeField]
	private float maximumDisplayRangeFromScreen = 20f;

	public GameObject playerGameObject { get; set;}

	private IAlertable m_trackedAlertable;
	public IAlertable trackedAlertable 
	{
		get 
		{ 
			return m_trackedAlertable;
		}
		set
		{
			m_trackedAlertable = value;
			m_trackedAlertable.DestroyEvent += OnTrackedDestroyed;
		}
	}

	void OnDestroy() 
	{
		if (m_trackedAlertable != null)
			m_trackedAlertable.DestroyEvent -= OnTrackedDestroyed;
	}

	void Start () {
		
	}

	void Update () {
		if (trackedAlertable != null && playerGameObject != null) {

			if (trackedAlertable.IsVisible) {
				alertText.text = "";
			}
			else 
			{
				float distance = (trackedAlertable.WorldPosition - playerGameObject.transform.position).magnitude;
				Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint (playerGameObject.transform.position);
				Vector3 trackedScreenPosition = Camera.main.WorldToScreenPoint (trackedAlertable.WorldPosition);
				transform.position = playerScreenPosition;
				bool left, right, bottom, top = false;
				SetAlertStatus (trackedAlertable.AlertStatus);
				//alertText.text = distance.ToString ();
				alertText.text = "";
			}
		}
	}

	private void SetAlertStatus(AlertStatus status) 
	{
		if (status == AlertStatus.WARNING)
			alertText.color = warningColor;
		else
			alertText.color = dangerColor;
	}

	private void OnTrackedDestroyed() {
		if(gameObject != null)
			Destroy (gameObject);
	}
}

public class CohenSutherlandClipping 
{
	private readonly int INSIDE = 0;
	private readonly int LEFT = 1;
	private readonly int RIGHT = 2;
	private readonly int BOTTOM = 4;
	private readonly int TOP = 8;

	private int x_max;
	private int y_max;

	public Vector3 ClipCoordinate(Vector3 coordinateOne, Vector3 coordinateTwo, int x_max, int y_max)
	{
		this.x_max = x_max;
		this.y_max = y_max;
		return Vector3.zero;
	}

	private int CalculateCode(float x, float y)
	{
		int code = INSIDE;

		if (x < 0)
			code |= LEFT;
		else if (x > x_max)
			code |= RIGHT;
		if (y < 0)
			code |= BOTTOM;
		else if (y > y_max)
			code |= TOP;

		return code;
	}
}
