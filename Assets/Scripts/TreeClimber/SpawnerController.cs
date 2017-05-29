using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	public static SpawnerController instance;
	int i;
	public GameObject[] obj;
	public bool[] NeedToSpawn;
	private bool[] PrevArray;
	public float HardTime=1f;
	public bool Active=true;
	public float Speed = 200f;
	public int NumberOfSpawners;
	// Use this for initialization
	void Start () {
		instance = this;
		PrevArray = new bool[]{false,false,false,false};
		StartCoroutine( Generate ());
	}
	
	public IEnumerator Generate()
	{
		yield return new WaitForSeconds (HardTime);
		if (Active) {
			Random.InitState ((int)System.DateTime.Now.Ticks);
			NeedToSpawn = new bool[4];
			for (i = 0; i < NumberOfSpawners; i++)
				NeedToSpawn [i] = false;
			i = NumberOfSpawners;
			if (PrevArray [0] == false){
				NeedToSpawn [0] = true;
				i--;
			}
			if (PrevArray [NumberOfSpawners - 1] == false) {
				NeedToSpawn [NumberOfSpawners - 1] = true;
				i--;
			}
			i = Random.Range (0, i);

			

			while (i > 0) {
				int buf = Random.Range (0, NumberOfSpawners-1);
				if (NeedToSpawn [buf] == false) {
					i--;
					NeedToSpawn [buf] = true;
				}
			}
			PrevArray = NeedToSpawn;
			GameObject[] Spawners = GameObject.FindGameObjectsWithTag ("Spawner");
			foreach (GameObject SpawnObj in Spawners)
				SpawnObj.GetComponent<SpawnerScript> ().Spawn ();
			StartCoroutine (Generate ());
		}
	}

}
