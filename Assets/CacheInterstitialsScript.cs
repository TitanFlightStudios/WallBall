﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartboostSDK;

public class CacheInterstitialsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Chartboost.cacheInterstitial(CBLocation.Default);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
