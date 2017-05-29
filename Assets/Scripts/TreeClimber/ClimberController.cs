using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberController : MonoBehaviour {
	private bool dead=false;
	private bool flying=false;
	public float MovementForceInJump=10f;
	private bool side=false; //false for connectin to RIGHT WALL, true for LEFT
	public float JumpForce=100f;
	private float speed;
	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		speed = (JumpForce / rb2d.mass) * Time.fixedDeltaTime;
	}

	void MakeDead(){
		dead = true;
		GameObject.FindGameObjectWithTag ("SpawnControl").GetComponent<SpawnerController>().Active=false;
		var enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (var enemy in enemys) {
			Destroy (enemy);
		}
		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Wall");
		foreach (GameObject wall in walls) 
			wall.GetComponent<BuldingMover> ().move = false;
		anim.SetTrigger ("Die");
		rb2d.gravityScale = 0;
		rb2d.velocity = Vector2.zero;
		rb2d.angularVelocity = 0;
		transform.rotation = Quaternion.identity;
		Invoke ("Punch", 1f);
	}

	void Punch()
	{
		rb2d.gravityScale = 1f;
		rb2d.AddForce (new Vector2(0f, 250f));
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -4.3 && dead==false)
			MakeDead ();
		if (dead == false) {
			if (side == true)
				if (rb2d.velocity.x > -speed)
					rb2d.AddForce (new Vector2 (-MovementForceInJump, 0));
			if (side == false)
				if (rb2d.velocity.x < speed)
					rb2d.AddForce (new Vector2 (MovementForceInJump, 0));
			if (Input.GetMouseButtonDown (0)) {
				
				if (!flying) {
					rb2d.velocity = Vector2.zero;
					if (side == false)
						rb2d.AddForce (new Vector2 (-JumpForce, 0));
					else
						rb2d.AddForce (new Vector2 (JumpForce, 0));
					anim.SetTrigger ("Flying");
					flying = true;

				}
				transform.Rotate (180, 0, 0);
				side = !side;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Wall") 
		{
			if (flying) {
				if (side == false && target.gameObject.name == "RightWall") {
					anim.SetTrigger ("Running");
					flying = false;
				}
				if (side == true && target.gameObject.name == "LeftWall") {
					anim.SetTrigger ("Running");
					flying = false;
				}
				
			}
		} else rb2d.gravityScale = 3f;
	}

	void OnCossisionExit2D (Collision2D tagret)
	{
		
	}
		
}
