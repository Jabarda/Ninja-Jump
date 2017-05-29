using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIStop : MonoBehaviour {
	Rigidbody2D rb2d;
	public float speed;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	public void Back()
	{
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed, 0f));
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -18.20f) {
			transform.position = new Vector3 (-18.15f, 0f, 10f);
			rb2d.velocity = Vector2.zero;
		};
		if (transform.position.x > 0.2f){
			transform.position = new Vector3 (0f, 0f, 10f);
			rb2d.velocity = Vector2.zero;
		};
	}
}
