﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCounter : MonoBehaviour {

    public int numberCollected = 0;
    public int totalNumber;

	// Use this for initialization
	void Start () {
        CollectorManager.CollectedEvent += OnCollect;
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollect(CollectableBehavior collected)
    {
        numberCollected = CollectorManager.Instance.CollectablesFound;
        totalNumber = CollectorManager.Instance.TotalNumberOfCollectables;
    }
}
