using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {
	public static PauseMenu instance;
	public bool Paused;
	// Use this for initialization
	void Start () {
		Paused = false;
		instance = this;
	}

	public void ShowMenu()
	{
		Paused = true;
		GetComponent<RectTransform> ().position = new Vector3 (0f, 0f, 0f);
	}

	public void HideMenu()
	{
		GetComponent<RectTransform> ().position = new Vector3 (0f, 30f, 0f);
	}
	public void Resume()
	{
		HideMenu ();
		GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource> ().UnPause();
		Time.timeScale = 1f;
		Paused = false;
	}
	public void ToMenu()
	{
		Time.timeScale = 1f;
		Destroy ( GameObject.FindGameObjectWithTag ("Audio"));
		StartCoroutine(FadeSceneloadScript.instance.FadeToClear("LoadingScreen"));
		Paused = false;
	}

}
