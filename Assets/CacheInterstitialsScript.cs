using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartboostSDK;

public class CacheInterstitialsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Chartboost.cacheInterstitial(CBLocation.Default);
        Chartboost.cacheRewardedVideo(CBLocation.Default);

        /** Cache rewarded video pre-roll message and video ad at location Main Menu. 
        See /assets/chartboost/scripts/chartboost.cs for available location options. **/

        Chartboost.cacheRewardedVideo(CBLocation.Default);

        if (Chartboost.hasRewardedVideo(CBLocation.Default)) 
        {
            Chartboost.showRewardedVideo(CBLocation.Default);
        }
        else
        {
            // We don't have a cached video right now, but try to get one for next time
            Chartboost.cacheRewardedVideo(CBLocation.Default);
            Debug.Log("Does not have a video cached");
        }



    }

    // Update is called once per frame
    void Update () {
		
	}
}
