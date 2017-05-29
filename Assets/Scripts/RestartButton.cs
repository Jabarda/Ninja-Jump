using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {
	void Start()
	{
		
	}

	public void Restart()
	{
		

		print ("RESTART");
		PlayerPrefs.SetInt ("TotalScoreLvl_1", PlayerPrefs.GetInt ("TotalScoreLvl_1") + ScoreManager.instance.CurrentScore);
		PlayerPrefs.Save ();
		//GooglePlayManager.instance.ShowAd ();
		StartCoroutine(FadeSceneloadScript.instance.FadeToClear("Spawning"));

	}
	/*
	#region Interstitial callback handlers
	public void onInterstitialLoaded() { Debug.Log ("loaded"); }
	public void onInterstitialFailedToLoad() { Debug.Log ("failed");StartCoroutine(FadeSceneloadScript.instance.FadeToClear("Spawning")); }
	public void onInterstitialShown() { Debug.Log ("shown");
		PlayerPrefs.SetInt ("AdsCount", 1);
		StartCoroutine(FadeSceneloadScript.instance.FadeToClear("Spawning")); 
	}
	public void onInterstitialClosed() { Debug.Log ("closed");StartCoroutine(FadeSceneloadScript.instance.FadeToClear("Spawning")); }
	public void onInterstitialClicked() { Debug.Log ("clicked");StartCoroutine(FadeSceneloadScript.instance.FadeToClear("Spawning")); }
	#endregion
	*/

}
