using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] obj;
	public bool spawn=true;
	public float BasicTime=0.5f;
	public static Spawner instance;
//	public float spawnMinTime = 0.5f;
//	public float spawnMaxTime = 1.5f;
	public float spawnTime = 0.5f;
	public float distanceTime = 1f;
	public float spawnMinHeight=1f;
	public float spawnMaxHeight=2f;
	public float speed = 200f;
	public float minGravity=1f;
	public float maxGravity=5f;
	private int CurrentUnlockedEnemy=13;
	// Use this for initialization
	void Start () {
		instance = this;
		Spawn ();
		instance = this;
	}
	
	// Update is called once per frame
	void Spawn()
	{
		if (PlayerPrefs.HasKey ("EnemyUnlocked")) {
			CurrentUnlockedEnemy = PlayerPrefs.GetInt ("EnemyUnlocked");
			print (CurrentUnlockedEnemy);
		}
		else {
			CurrentUnlockedEnemy = 10;
			PlayerPrefs.SetInt ("EnemyUnlocked", 10);
		};

		if (spawn == true) {
			Random.InitState (System.DateTime.Now.Millisecond);
			GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x,Random.Range(-2,3f));
			Instantiate (obj [Random.Range (0, CurrentUnlockedEnemy)], transform.position, Quaternion.identity);

			Invoke ("Spawn", Random.Range (spawnTime, spawnTime+distanceTime));
		}
	}

}
