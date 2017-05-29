using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtons : MonoBehaviour {
	public float speed = 600f;
	public static MoveButtons instance;
	void Start()
	{
		instance = this;
	}
	public void MoveBut()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed,0f));
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -5.2f)
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
}
