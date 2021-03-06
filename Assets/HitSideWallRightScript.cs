﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSideWallRightScript : MonoBehaviour {

    //Other scripts
    public SpawnBallScript SpawnBallScript;
    public BallBehaviorScript BallBehaviorScript;
    public CatchBallScript CatchBallScript;
    public ScoringScript ScoringScript;
    public RotateWallScript RotateWallScript;
    public RedCubeKillBallScript RedCubeKillBallScript;

    public bool didBallHitSideWallRight;

    //Vector3 to use for displaying the +0.25 UI Game Object
    public Vector3 LocationToDisplayWallHitMultR;

    //Game Object that displays + 0.25 X
    public GameObject BallHitWallMultGameObject;

    //Variables for the Fade Function
    public float fFadeSpeed;
    public float fFadeDuration;
    public Text WallHitMultGameObject;
    public Color WallHitMultColor;
    public Image WallHitMultBGGameObject;
    public Color WallHitMultBGColor;




    // Use this for initialization
    void Start () {

        //Initiate the inital color of the score display component
        WallHitMultGameObject.GetComponent<Text>();
        WallHitMultColor = WallHitMultGameObject.color;
        WallHitMultBGGameObject.GetComponent<Image>();
        WallHitMultBGColor = WallHitMultBGGameObject.color;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Rigidbody of the Red Cube that hits the wall
        Rigidbody RedCubeRigidbody;

        if(collision.gameObject.tag == "Ball")
        {
            didBallHitSideWallRight = true;

                //Increase score multiplier
                ScoringScript.IncreaseScoreMultiplier(0.25f);

                //Note hit for WallsHitNum
                ScoringScript.WallsHitNum += 0.25f;

            CatchBallScript.fSumOfCatchesAndWallHitMult += 0.25f;

            //The spot where the ball hit the floor
            LocationToDisplayWallHitMultR = collision.contacts[0].point;
            //Debug.Log("Contact point: " + collision.contacts[0].point);

            //Increase the y value so that it does not intersect with the floor
            LocationToDisplayWallHitMultR = new Vector3(LocationToDisplayWallHitMultR.x - 1.0f, LocationToDisplayWallHitMultR.y + 1.0f, LocationToDisplayWallHitMultR.z);

            StartCoroutine(FadeWallHitMult());

            //Display the UI Game Object showing + 0.25 X Game Object
            BallHitWallMultGameObject.transform.position = LocationToDisplayWallHitMultR;

        }

        if (collision.gameObject.tag == "RedCube")
        {
            RedCubeRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (RedCubeRigidbody.velocity.x < RedCubeKillBallScript.fCubeMaxSpeed)
            {
                //Add force to the cube to continue its momentum
                RedCubeRigidbody.AddForce(-0.5f, 0, 0, ForceMode.Impulse);
            }
            else
            {
                //if the cube is going over the set max speed, then set the velocity of the cube to the max speed while keeping other values as they were
                RedCubeRigidbody.velocity = new Vector3(RedCubeKillBallScript.fCubeMaxSpeed, RedCubeRigidbody.velocity.y);
            }
        }
    }

    public IEnumerator FadeWallHitMult()
    {
        BallHitWallMultGameObject.SetActive(true);



        //Set the speed to fade from full alpha to 0 over time (1/10) would be 10 seconds (1/5) 5 seconds, and so on
        fFadeSpeed = (float)1.0 / fFadeDuration;

        WallHitMultGameObject.CrossFadeAlpha(1, 2, false);

        //for loop that fades from 0 alpha to 1 over a time that is the change of time times the fade speed
        for (float fFadeTime = 0.0f; fFadeTime < 1.0f; fFadeTime += Time.deltaTime * fFadeSpeed)
        {
            //Alpha changes over a lerp from 1 to 0 over a time that lasts an amount of fFadeTime
            WallHitMultColor.a = Mathf.Lerp(1, 0, fFadeTime);
            //WallHitMultBGColor.a = Mathf.Lerp(1, 0, fFadeTime);
            //Sets Alpha that does the "fade"
            WallHitMultGameObject.color = WallHitMultColor;
            //WallHitMultBGGameObject.color = WallHitMultBGColor;
            yield return true;
        }
        BallHitWallMultGameObject.SetActive(false);
    }
}
