using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour {
	public static Controller instance;
	private bool punched=false;
	public float speed = 200f;
	public float SpeedForce=200f;
	public float ClimbSpeed=50f;
	//public bool MoveBackround=false;
	private float timer = 0;
	public float jump_force = 600f;
	public GameObject[] obj;
	public double jumps_available=2;
	public bool isDead = false;
	//private bool direction = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	private Touch myTouch;
	private bool running = true;
	private bool AbleToJump=false;
	Transform transformer;
	// Use this for initialization
	void Start () {
		//ninja = GetComponent<GameObject> ();
		instance=this;
		AbleToJump=false;
		Invoke ("StartJumps", 0.3f);
		transformer = GetComponent<Transform>();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		//MoveBackround = true;
	}

	void StartJumps()
	{
		AbleToJump = true;
	}

	public void Jump()
	{
		if (jumps_available > 0 && !isDead && AbleToJump) {

			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (rb2d.mass * new Vector2 (0, jump_force));
			jumps_available--;
		}
	}

	// Update is called once per frame
	void Update () {
		if (transformer.position.y <= -6)
			Destroy (this.gameObject);
		if (isDead == false) {
			rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
			if (transformer.position.x < -5.25) {
				
				rb2d.AddForce (rb2d.mass * new Vector2 (SpeedForce, 0));
			}

			if (rb2d.velocity.y > 1.5f) {
				running = false;
				anim.SetTrigger ("Up");
			} else if (rb2d.velocity.y < -1.5f) {
				anim.SetTrigger ("Down");
				running = false;
			} else if (running == false) {
				anim.SetTrigger ("Running_Right");
				running = true;
			}
			if (Input.GetMouseButtonDown(0))
			if ( !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && !PauseMenu.instance.Paused)
				Jump();

		} 
		else 
		{
			
			timer += Time.deltaTime;
			if (timer > 1f) {
				if (punched==false) {
					rb2d.AddForce(new Vector2(0f,250f*rb2d.mass));
					rb2d.gravityScale = 1f;
					GetComponent<BoxCollider2D> ().enabled = false;
					punched = true;
				};
			}
		}

	}
		
	void Dead()
	{
		GetComponent<AudioSource> ().Play ();
		isDead = true;
		rb2d.gravityScale=0f;
		rb2d.velocity = Vector2.zero;
		var moving = GameObject.FindGameObjectsWithTag ("MovingBackground");
		foreach (var mov in moving) {
			mov.GetComponent<MovingBackground> ().move = false;
		}
		//MoveBackround = false;
		Spawner.instance.spawn = false;
		var enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (var enemy in enemys) {
			Destroy (enemy);

		}
		anim.SetTrigger ("Die");
		GameOverButton.instance.MoveUp();
	}


	void OnCollisionEnter2D (Collision2D target)
	{
		if (!isDead) {
			//anim.SetTrigger ("Idle");
			//print(target.gameObject.name);
			if (target.gameObject.name == "Ground") {
				Dead ();
				//anim.SetTrigger ("Die");
			} else {
				//ContactPoint2D contact = target.contacts [0];
				//if (Vector2.Dot (contact.normal, Vector2.up) > 0.5) {
				//	jumps_available = 2;
				//}
				//rb2d.velocity = Vector2.zero;
				ContactPoint2D contact = target.contacts [0];
				if (Vector2.Dot (contact.normal, Vector2.left) ==1f && target.gameObject.name != "SpawnBlock") {
					//float buf = Mathf.Max(rb2d.velocity.y,0f));
				
					rb2d.velocity = Vector2.zero;
					rb2d.AddForce (new Vector2 (0, rb2d.mass * ClimbSpeed*Mathf.Sqrt(rb2d.gravityScale)));
				}
				if (Vector2.Dot (contact.normal, Vector2.up) >=0 && target.gameObject.name != "SpawnBlock") {
					//float buf = Mathf.Max(rb2d.velocity.y,0f));

					rb2d.velocity = Vector2.zero;
					rb2d.AddForce (new Vector2 (0, rb2d.mass * 1.25f * jump_force));
				}

				//	jumps_available = 2;
				//}
			}
		}
	}
	void OnCollisionStay2D (Collision2D target)
	{
		if (!isDead) {
			ContactPoint2D contact = target.contacts [0];
			if (Vector2.Dot (contact.normal, Vector2.left) ==1 && target.gameObject.name!="SpawnBlock"){
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0f, rb2d.mass * ClimbSpeed*Mathf.Sqrt(rb2d.gravityScale)));
			}
		}
	}
	void OnCollisionExit2D(Collision2D target)
	{
		if (!isDead) {
			ContactPoint2D contact = target.contacts [0];

			print (Vector2.Dot (contact.normal, Vector2.up));
			if (Vector2.Dot (contact.normal, Vector2.up) >=0) {
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, rb2d.mass * 1.25f * jump_force));
				jumps_available = 2;
			}

			
		}
	}
}
