using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartboostSDK;

public class ShowAdScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ShowAdFunction()
    {
        // Show interstitial at location HomeScreen. 
        // See Chartboost.cs for available location options.
        Chartboost.showInterstitial(CBLocation.HomeScreen);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
