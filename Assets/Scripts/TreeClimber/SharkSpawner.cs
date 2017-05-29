using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour {
	public float SharkSpeed=50;
	public static SharkSpawner instance;
	public GameObject Shark;
	// Use this for initialization
	void Start () {
		instance = this;
		begin ();
	}
	public void begin()
	{
		transform.position = new Vector2 (-9.85f, -4.62f);
		Invoke ("Move", Random.Range (1f, 10f));
	}
	void Move()
	{
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (SharkSpeed,0f));
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 10) {
			GameObject buf = Instantiate (Shark);
			buf.GetComponent<SharkSpawner> ().begin ();
			Destroy (gameObject);

		}
	}
}
