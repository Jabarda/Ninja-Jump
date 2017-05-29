using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour {

	void Start()
	{
		

	}

	public void MoveToMenu()
	{
		
		PlayerPrefs.Save ();
		StartCoroutine (FadeSceneloadScript.instance.FadeToClear ("LoadingScreen"));

	}
	/*
	#region Interstitial callback handlers
	public void onInterstitialLoaded() { print("Interstitial loaded"); }
	public void onInterstitialFailedToLoad() { StartCoroutine(FadeSceneloadScript.instance.FadeToClear("LoadingScreen")); }
	public void onInterstitialShown() { 
		PlayerPrefs.SetInt ("AdsCount", 1);
		StartCoroutine(FadeSceneloadScript.instance.FadeToClear("LoadingScreen")); 
	}
	public void onInterstitialClosed() { StartCoroutine(FadeSceneloadScript.instance.FadeToClear("LoadingScreen")); }
	public void onInterstitialClicked() { StartCoroutine(FadeSceneloadScript.instance.FadeToClear("LoadingScreen")); }
	#endregion
	*/
}
