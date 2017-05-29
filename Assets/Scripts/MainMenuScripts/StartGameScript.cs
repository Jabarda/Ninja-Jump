using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;

public class StartGameScript : MonoBehaviour {
	public float speed=600f;
	// Use this for initialization
	void Start () {
		//string appKey = "cefe8ab4a843bec143733824a755bd011397e03c398a9f7d";
		//Appodeal.disableLocationPermissionCheck();
		//Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO);
	}
	public void StartGame()
	{
		//Appodeal.show(Appodeal.INTERSTITIAL);
		//PlayGamesPlatform.Activate ();
		//if (!Social.localUser.authenticated)
		//	Social.localUser.Authenticate ((bool success) => {
		//	});
		//if (Social.localUser.authenticated) Social.ShowAchievementsUI();


		//MOVE CANVAS TO RIGHT HERE
		print ("hello");
		GameObject.FindGameObjectWithTag("MainUI").GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed,0));
	}
	// Update is called once per frame
	void Update () {
		//print(Appodeal.isLoaded(Appodeal.INTERSTITIAL));
		
	}
}
