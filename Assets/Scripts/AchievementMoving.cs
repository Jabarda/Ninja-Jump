using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMoving : MonoBehaviour {
	public static AchievementMoving instance;
	Rigidbody2D rb2d;
	public float speed=200f;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	public void show()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (new Vector2 (0, -1 * speed));
		Invoke ("pause", 1f);
	}
	void pause()
	{
		rb2d.AddForce (new Vector2 (0, speed));
		Invoke ("up", 2f);
	}
	void up()
	{
		rb2d.AddForce (new Vector2 (0, speed));
		Invoke ("die", 1f);
	}
	void die()
	{
		rb2d.AddForce (new Vector2 (0, -1 * speed));
	}
	// Update is called once per frame
}
