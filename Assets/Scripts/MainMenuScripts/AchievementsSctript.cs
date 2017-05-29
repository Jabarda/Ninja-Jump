using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class AchievementsSctript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void ShowAchievements()
	{
		if (!PlayGamesPlatform.Instance.IsAuthenticated())
			PlayGamesPlatform.Instance.Authenticate ((bool success) => {
			});
		if (PlayGamesPlatform.Instance.IsAuthenticated())
			PlayGamesPlatform.Instance.ShowAchievementsUI ();
	}

	public void ShowRanks()
	{
		(Social.Active as GooglePlayGames.PlayGamesPlatform).SetDefaultLeaderboardForUI (GPGSIds.leaderboard_top_ninjas);
		if (!PlayGamesPlatform.Instance.IsAuthenticated())
			PlayGamesPlatform.Instance.Authenticate ((bool success) => {
			});
		if (PlayGamesPlatform.Instance.IsAuthenticated())
			PlayGamesPlatform.Instance.ShowLeaderboardUI ();
	}


}
