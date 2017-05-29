using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour {
	Rigidbody2D rb2d;
	public float JumpForce;
	private int Jumps_Available;
	private bool dead=false;
	public float MoveForce = 50f;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		JumpForce = JumpForce * rb2d.mass * Mathf.Sqrt (rb2d.gravityScale);
	}

	void die()
	{
	}

	// Update is called once per frame
	void Update () {
		if (!dead) {
			if (transform.position.x < -5.25) {
				//rb2d.velocity = new Vector2 (0f,rb2d.velocity.y);
				//rb2d.AddForce (new Vector2 (MoveForce, 0f));
			}
			if (Input.GetMouseButtonDown (0) && Jumps_Available>0) {
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0f, JumpForce));
				Jumps_Available--;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D target)
	{
		ContactPoint2D contact = target.contacts [0];
		print (Vector2.Dot (contact.normal, Vector2.up));
		if (!dead)
		if (target.gameObject.name == "Ground") {
			//dead = !dead;
			die ();
		} else {
			
			if (Vector2.Dot (contact.normal, Vector2.up) > 0.9f) {
				Jumps_Available = 2; 
			}
		}

	}
	/*
	void OnCollisionExit2D (Collision2D target)
	{
		if (!dead)
		if (target.gameObject.name == "Ground") {
			//dead = !dead;
			die ();
		} else {
			ContactPoint2D contact = target.contacts [0];
			if (Vector2.Dot (contact.normal, Vector2.right) >0.9f ) {
				if (rb2d.velocity.y<0) rb2d.velocity = new Vector2 (rb2d.velocity.x, 0f);
				rb2d.AddForce (new Vector2 (0f, JumpForce));
				Jumps_Available--;
			}
		}
		//if (!dead)
	}*/
}
