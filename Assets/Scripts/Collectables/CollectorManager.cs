using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorManager : MonoBehaviour {

	private static CollectorManager instance;
	public static CollectorManager Instance { get { return instance; } }

	private List<CollectableBehavior> collectables;

	public int CollectablesFound 
	{ 
		get
		{
			int i = 0;
			foreach (var collectable in collectables)
				i += collectable.IsCollected ? 1 : 0;
			return i;
		} 
	}

	public void Awake() 
	{
		instance = this;
	}

	public void RegisterCollectable(CollectableBehavior collectable) 
	{
		collectables.Add (collectable);
	}
}
