using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
	
	public int number;
	private GameObject buf;
	// Use this for initialization
	void Start () {
		
	}
	

	public void Spawn(){
		if (SpawnerController.instance.NeedToSpawn [number] == true) {
			buf = Instantiate (SpawnerController.instance.obj [Random.Range (0, SpawnerController.instance.obj.GetLength (0))], transform.position, Quaternion.identity);
			buf.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -1 * SpawnerController.instance.Speed));
		}
	}
}
