using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiscoreMainMenu : MonoBehaviour {
	public static HiscoreMainMenu instance;
	public int HighScore = 0;
	public int Total = 0;
	public Text text;
	// Use this for initialization
	void Start () {
		instance = this;
		text = GetComponent<Text> ();
		if (PlayerPrefs.HasKey ("HighScore"))
			HighScore = PlayerPrefs.GetInt ("HighScore");
		else
			PlayerPrefs.SetInt ("HighScore", 0);
		text.text="HISCORE: "+HighScore;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
