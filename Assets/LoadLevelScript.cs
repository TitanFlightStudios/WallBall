using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ChartboostSDK;

public class LoadLevelScript : MonoBehaviour {

    //Other scripts
    //public SpawnBallScript SpawnBallScript;
    //public KillBallScript KillBallScript;
    public BallBehaviorScript BallBehaviorScript;
    //public ScoringScript ScoringScript;
    //public RotateWallScript RotateWallScript;
    //public HitSideWallRightScript HitSideWallRightScript;
    //public HitSideWallLeftScript HitSideWallLeftScript;
    //public SpawnMovingObjectScript SpawnMovingObjectScript;

    // Use this for initialization
    void Start() {

        //Starting of the app
        Screen.orientation = ScreenOrientation.Portrait;

        Chartboost.cacheRewardedVideo(CBLocation.MainMenu);

    }

    public void LoadLevelFunction(int LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void ChangeBallSkin(int SkinToChangeTo)
    {
        //Change the material of the ball so that it is not catchable
        BallBehaviorScript.BallRenderer.sharedMaterial = BallBehaviorScript.materials[SkinToChangeTo];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
