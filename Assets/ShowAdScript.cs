using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartboostSDK;

public class ShowAdScript : MonoBehaviour {

    [HideInInspector]
    //variable to keep track of how many times the player failed to catch the ball
    public int numMissedCatches;

    [HideInInspector]
    //variable to determine when to activate the ad
    public int numActivateAd;

	// Use this for initialization
	void Start () {
		
	}

    public void ShowAdFunction()
    {

        Debug.Log("Running Ad Function");

        if (numMissedCatches > 10)
        {

            Debug.Log("Misses higher than 5");

            numActivateAd = Random.Range(0, 100);

            if (numActivateAd < 30 + (2 * numMissedCatches))
            {
                // Show interstitial at location HomeScreen. 
                // See Chartboost.cs for available location options.
                //Chartboost.showRewardedVideo(CBLocation.MainMenu);
                Chartboost.showInterstitial(CBLocation.Default);
                Debug.Log("Show Ad");
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
