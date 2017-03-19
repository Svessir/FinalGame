using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollectedAction();
public delegate void RegisterAction();

public class CollectorManager : MonoBehaviour {

	private static CollectorManager instance;
	public static CollectorManager Instance { get { return instance; } }
	public static event CollectedAction CollectedEvent;
	public static event RegisterAction RegisterEvent;

	private List<CollectableBehavior> collectables = new List<CollectableBehavior>();

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

	public int TotalNumberOfCollectables { get{ return collectables.Count; } }

	public void Awake() 
	{
		instance = this;
	}

	public void RegisterCollectable(CollectableBehavior collectable) 
	{
		if (!collectables.Contains (collectable)) {
			collectables.Add (collectable);

			if (RegisterEvent != null)
				RegisterEvent ();
		}
	}

	public void OnTriggerEnter(Collider collider)
	{
		CollectableBehavior collectable = collider.GetComponent<CollectableBehavior> ();
		
		if (collectable != null) 
		{
            if (collectables.Contains (collectable) && !collectable.IsCollected) 
			{
				collectable.Collect ();

				if (CollectedEvent != null)
					CollectedEvent ();
			}
		}
	}
}
