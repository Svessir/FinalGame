using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DestroyAction();
public interface IAlertable 
{
	event DestroyAction DestroyEvent;
	Vector3 WorldPosition { get; }
	AlertStatus AlertStatus { get; }
	GameObject gameObject { get; }
	bool IsVisible { get; }

}

public enum AlertStatus 
{
	WARNING,
	DANGER
}
