using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	// Use this for initialization
	public GameObject Ground;
	public GameObject BackGround;
	int buf = -1;
	void Start () {
		//PlayerPrefs.SetInt ("EnemyUnlocked", 10);
	}


	void OnCollisionEnter2D (Collision2D target)
	{
		//anim.SetTrigger ("Idle");
		//print(target.gameObject.name);
		//if (target.gameObject.name=="Ground") SpawnGround();
		//if (target.gameObject.tag == "BackGround")
		//	SpawnBackGround ();
		buf++;
		if (buf>0) ScoreManager.instance.NewScore ();

		LevelIncresing.instance.IncLevel ();
		if (buf == 40 && PlayerPrefs.GetInt ("EnemyUnlocked") == 10) {
			//PlayerPrefs.SetInt ("EnemyUnlocked", 11);
			if (GooglePlayManager.instance.UnlockAchi ("cow")) PlayerPrefs.SetInt ("EnemyUnlocked", 11);
			//GameObject.FindGameObjectWithTag("Achievement").GetComponent<AchievementTextControl> ().SetText ("Achievement unlocked\nThere is no cow level");
		}
		if (buf == 70 && PlayerPrefs.GetInt ("EnemyUnlocked") == 11) {
			//PlayerPrefs.SetInt ("EnemyUnlocked", 12);
			if (GooglePlayManager.instance.UnlockAchi ("Ghost")) PlayerPrefs.SetInt ("EnemyUnlocked", 12);
			//GameObject.FindGameObjectWithTag("Achievement").GetComponent<AchievementTextControl> ().SetText ("Achievement unlocked\nGhostBuster");
		}
		if (buf == 100 && PlayerPrefs.GetInt ("EnemyUnlocked") == 12) {
			
			if (GooglePlayManager.instance.UnlockAchi ("Hero"))PlayerPrefs.SetInt ("EnemyUnlocked", 13);
			//GameObject.FindGameObjectWithTag("Achievement").GetComponent<AchievementTextControl> ().SetText ("Achievement unlocked\nEpic hero");
		}
		Destroy (target.gameObject);

	}
}
