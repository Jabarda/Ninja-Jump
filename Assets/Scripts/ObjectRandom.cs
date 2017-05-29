using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandom : MonoBehaviour {
	public ObjectRandom instance; 
	Rigidbody2D rb2d;
	//public float spawnMin=10f,spawnMax=20f;
	//public float speed = 200f;
	// Use this for initialzation
	void Start () {
		instance = this;
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.gravityScale = Random.Range (Spawner.instance.minGravity, Spawner.instance.maxGravity);
		rb2d.AddForce (rb2d.mass*new Vector2 (-1*Spawner.instance.speed,-1*Mathf.Sqrt(rb2d.gravityScale)* Random.Range (Spawner.instance.spawnMinHeight, Spawner.instance.spawnMaxHeight)));
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	//public void SetStartValues(float speed, float h);
}
