using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayManager : MonoBehaviour {
	public static GooglePlayManager instance;
	private AudioSource AudioSrc;

	//bool success = false;
	//bool IsConnectedToGooglePlay=false;

		// enables saving game progress.
		// registers a callback to handle game invitations received while the game is not running.
		// require access to a player's Google+ social graph (usually not needed)

	int count=0, games_count=0;
	void Awake() {
		
		DontDestroyOnLoad(transform.gameObject);
	}

		
	// Use this for initialization
	void Start () {
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("PlayManager");
		if (enemys.GetLength (0) != 1)
			Destroy (transform.gameObject);
		instance = this;
		games_count = 0;
		count = 0;

		AppLovin.InitializeSdk ();
		AppLovin.PreloadInterstitial ();
		AppLovin.SetUnityAdListener (gameObject.name);
		//AdMob init

		//Admob.Instance ().initAdmob ("ca-app-pub-5744130550718724/8983149295", "ca-app-pub-5744130550718724/6345910496");
		//Admob.Instance().loadInterstitial(); 
		//RequestBanner ();
		//ShowBannerTop ();
		//RequestInterstitial ();
		//Chartboost.cacheInterstitial (CBLocation.HomeScreen);
		//StartApp

		AudioSrc = GetComponent<AudioSource> ();
		PlayGamesPlatform.Activate ();
		PlayGamesPlatform.Instance.Authenticate ((bool success) => {
			//IsConnectedToGooglePlay = success;
		});
		SetHiScore ();

		//Social.ReportScore (PlayerPrefs.GetInt ("HighScore"), "FirstDaily", GPGSIds.leaderboard_top_ninjas, (bool success) => {
		//});
		if (PlayerPrefs.HasKey("Pirate") )
			GooglePlayManager.instance.UnlockAchi("Pirate");
		if (PlayerPrefs.HasKey("Maiden")) 
			GooglePlayManager.instance.UnlockAchi("Maiden");
		if (PlayerPrefs.HasKey("Samurai")) 
			GooglePlayManager.instance.UnlockAchi("Samurai");
		if (PlayerPrefs.HasKey("Spy")) 
			GooglePlayManager.instance.UnlockAchi("Spy");
		if (PlayerPrefs.HasKey("Ranger")) 
			GooglePlayManager.instance.UnlockAchi("Ranger");
		
		if (PlayerPrefs.GetInt ("HighScore") >= 40) {
			GooglePlayManager.instance.UnlockAchi ("cow");
			PlayerPrefs.SetInt ("EnemyUnlocked", 11);
		}
			
		if (PlayerPrefs.GetInt ("HighScore") >= 70) {
			GooglePlayManager.instance.UnlockAchi ("Ghost");
			PlayerPrefs.SetInt ("EnemyUnlocked", 12);
		}
			
		if (PlayerPrefs.GetInt ("HighScore") >= 100) {
			GooglePlayManager.instance.UnlockAchi ("Hero");
			PlayerPrefs.SetInt ("EnemyUnlocked", 13);
		}
		
		
	}

	public bool UnlockAchi(string s)
	{
		bool ret = false;
		if (PlayGamesPlatform.Instance.IsAuthenticated()) {
			if (s == "cow" && !PlayerPrefs.HasKey ("cow"))
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_there_is_no_cow_level, 100.0f, (bool success) => {
					AudioSrc.Play();
					ret = success;
					PlayerPrefs.SetInt ("cow", 1);
					if (success)
						PlayerPrefs.SetInt ("EnemyUnlocked", 11);
					if (success)
						PlayGamesPlatform.Instance.IncrementAchievement (GPGSIds.achievement_story_mode, 1, (bool nothing) => {
						});
				});

			if (s == "Ghost" && !PlayerPrefs.HasKey ("Ghost"))
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_ghostbuster, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
					PlayerPrefs.SetInt ("Ghost", 1);
					if (success)
						PlayerPrefs.SetInt ("EnemyUnlocked", 12);
					if (success)
						PlayGamesPlatform.Instance.IncrementAchievement (GPGSIds.achievement_story_mode, 1, (bool nothing) => {
						});
				});
			if (s == "Hero" && !PlayerPrefs.HasKey ("Hero"))
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_epic_hero, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
					PlayerPrefs.SetInt ("Hero", 1);
					if (success)
						PlayerPrefs.SetInt ("EnemyUnlocked", 13);
					if (success)
						PlayGamesPlatform.Instance.IncrementAchievement (GPGSIds.achievement_story_mode, 1, (bool nothing) => {
						});
				});
			if (s == "Spy")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_agent_337, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Samurai")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_samurai_its_like_ninja_but_samurai, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Ranger")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_what_did_the_ranger_forget_in_the_city, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Pirate")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_im_not_a_pirate_im_a_captain, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Maiden")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_best_present, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Big jump")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_ultra_mega_high_jump, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Left_dissapear")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_im_still_alive, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
			if (s == "Heaven")
				PlayGamesPlatform.Instance.ReportProgress (GPGSIds.achievement_stairway_to_heaven, 100.0f, (bool success) => {
					ret = success;
					AudioSrc.Play();
				});
		}
		return ret;
	}
	public void SetHiScore()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated()) 
		PlayGamesPlatform.Instance.ReportScore(PlayerPrefs.GetInt ("HighScore"), GPGSIds.leaderboard_top_ninjas, (bool success) => {
		});

	}

	public void ShowAd()
	{
		//HideBanner ();
		games_count++;
		count+=ScoreManager.instance.CurrentScore;
		if (games_count>=4 && count >= 300 && AppLovin.HasPreloadedInterstitial()) {
			Time.timeScale = 0f;
			AppLovin.ShowInterstitial ();
			Time.timeScale = 1f;
			count = 0;
			games_count = 0;
		}

	}


	/*
	void onAppLovinEventReceived(string ev){
		if(ev.Contains("DISPLAYEDINTER")) {
			Time.timeScale = 0f;
		}
		if(ev.Contains("HIDDENINTER")) {
			Time.timeScale = 1f;
			AppLovin.PreloadInterstitial();
		}
		if(ev.Contains("VIDEOBEGAN")) {
			Time.timeScale = 0f;
		}
		if(ev.Contains("VIDEOSTOPPED")) {
			Time.timeScale = 1f;
			AppLovin.PreloadInterstitial();
		}
		if(ev.Contains("LOADINTERFAILED")) {
			Time.timeScale = 1f;
			AppLovin.PreloadInterstitial();
		}
	}

	public void ShowVideo()
	{
		
	}
	*/
}
