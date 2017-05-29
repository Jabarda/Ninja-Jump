using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalScores : MonoBehaviour {
	public static FinalScores instance;
	public float UpdateSpeed = 0.5f;
	public float AnimationTime = 2f;
	private float PrevMoney, StartMoney;
	private AudioSource clip;
	private Text label;
	void Start()
	{
		clip = GetComponent<AudioSource> ();
		instance = this;
		PrevMoney = PlayerPrefs.GetInt ("Money");
		StartMoney = PrevMoney;
		label = GetComponent<Text> ();
	}

	public void ShowScores () {
		label.text = ScoreManager.instance.CurrentScore + "\n\n" + ScoreManager.instance.HighScore+"\n\n"+PrevMoney;	
	}

	public void MoneyRecalc()
	{
		if (PrevMoney < PlayerPrefs.GetInt ("Money")) {
			PrevMoney++;
			clip.Play ();
			label.text = ScoreManager.instance.CurrentScore + "\n\n" + ScoreManager.instance.HighScore+"\n\n"+PrevMoney;
			Invoke ("MoneyRecalc", (float)AnimationTime/(float)(PlayerPrefs.GetInt ("Money")-StartMoney));
		}
	}
}
