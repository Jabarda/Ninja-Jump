using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;
	public int CurrentScore;
	public int HighScore;
	private int Mult=0;
	public int MultSpeed=50;
	private bool pinging = false;
	private bool x2 = false;
	private bool x4 = false;
	private int count;
	Text text;
	// Use this for initialization
	void Start () {
		instance = this;

		GetComponent<Text> ().color = Color.yellow;
		CurrentScore = 0;
		HighScore = PlayerPrefs.GetInt ("HighScore");
		text = GetComponent<Text> ();
		NewScore ();
		count = 0;
		Mult = 1;

	}
		

	public void NewScore () {
		count++;
		if (count%25==0) {
			Mult++;
			MultiplierController.instance.SetMult (Mult);
		}
		
		CurrentScore+=Mult; 
		if (CurrentScore >= HighScore) {
			PlayerPrefs.SetInt ("HighScore", CurrentScore);
			if (!pinging) {
				ping ();
				pinging = true;
			}
		}
		HighScore = PlayerPrefs.GetInt ("HighScore");
		text.text="SCORE: "+CurrentScore+"\nHISCORE: "+HighScore;
			
	}
	void ping()
	{
		if (GetComponent<Text> ().color == Color.yellow)
			GetComponent<Text> ().color = Color.red;
		else GetComponent<Text> ().color = Color.yellow;
		Invoke ("ping", 0.5f);
	}
}
