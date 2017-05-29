using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameOverButton : MonoBehaviour {
	public static GameOverButton instance;
	private Rigidbody2D rb2d;
	public float speed=200f;
	private bool AchiButtonsMoved=false;
	Transform transformer;
	// Use this for initialization
	void Start () {
		instance = this;	
		transformer = GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	public void MoveUp()
	{	
		GooglePlayManager.instance.ShowAd ();
		PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") + ScoreManager.instance.CurrentScore);	
		if (PlayGamesPlatform.Instance.IsAuthenticated()) GooglePlayManager.instance.SetHiScore ();
		FinalScores.instance.ShowScores ();
		rb2d.AddForce (new Vector2 (0, speed));
	}



	// Update is called once per frame
	void Update () {
		if (transformer.position.y > 0f) {
			rb2d.velocity = Vector2.zero;
			if (!AchiButtonsMoved) {
				MoveButtons.instance.MoveBut ();
				FinalScores.instance.MoneyRecalc ();
				AchiButtonsMoved = true;
			}
		}
	}
}
