using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHitWallScript : MonoBehaviour
{

    //Other scripts
    public CatchBallScript CatchBallScript;
    public ScoringScript ScoringScript;

    //Vector3 to use for displaying the +0.25 UI Game Object
    public Vector3 LocationToDisplayWallHitMult;

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
    void Start()
    {
        //Initiate the inital color of the score display component
        WallHitMultGameObject.GetComponent<Text>();
        WallHitMultColor = WallHitMultGameObject.color;
        WallHitMultBGGameObject.GetComponent<Image>();
        WallHitMultBGColor = WallHitMultBGGameObject.color;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collided");

        if (collision.gameObject.tag == "Ball")
        {
            //Increase score multiplier
            //ScoringScript.IncreaseScoreMultiplier(0.25f);

            //Note hit for WallsHitNum
            //ScoringScript.WallsHitNum += 0.25f;

            //CatchBallScript.fSumOfCatchesAndWallHitMult += 0.25f;

            //The spot where the ball hit the floor
            LocationToDisplayWallHitMult = collision.contacts[0].point;
            //Debug.Log("Contact point: " + collision.contacts[0].point);

            //Increase the y value so that it does not intersect with the floor
            //LocationToDisplayWallHitMult = new Vector3(LocationToDisplayWallHitMult.x, LocationToDisplayWallHitMult.y, LocationToDisplayWallHitMult.z);

            StartCoroutine(FadeWallHitMult());

            //if (LocationToDisplayWallHitMult.x > -7.0f && LocationToDisplayWallHitMult.x < -4.8f)
            //{
            //    LocationToDisplayWallHitMult.x = -4.5f;
            //}

            ////Debug.Log("Location of Ball Hit Floor: " + LocationToDisplayWallHitMult.x);

            //if (LocationToDisplayWallHitMult.x < 9.0f && LocationToDisplayWallHitMult.x > 6.0f)
            //{
            //    LocationToDisplayWallHitMult.x = 6.0f;
            //}

            //Display the UI Game Object showing + 0.25 X Game Object
            BallHitWallMultGameObject.transform.position = LocationToDisplayWallHitMult;

            Debug.Log("Hit Main Wall");

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
