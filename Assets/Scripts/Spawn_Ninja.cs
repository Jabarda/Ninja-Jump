using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_Ninja : MonoBehaviour {
	private bool IsGrounded=false;
	//private Rigidbody2D rb2d;
	private float timer = 0f;
	AsyncOperation op;
	Animator anim;
	// Use this for initialization
	IEnumerator Start () {
		op = SceneManager.LoadSceneAsync ("main");
		op.allowSceneActivation = false;
		//rb2d = GetComponent<Rigidbody2D>();
		anim= GetComponent<Animator> ();
		yield return op;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsGrounded == true){
			timer += Time.deltaTime;
			if (timer > 0.5f && timer < 1.5f)
				anim.SetTrigger ("Hello");
			if (timer > 1.5f) {
				anim.SetTrigger ("idle");
				ReadyManager.instance.SetText ("GO");
			}
			if (timer > 2f)
				op.allowSceneActivation = true;
		}
		if (Input.GetMouseButtonDown (0))
			op.allowSceneActivation = true;

	}

	void OnCollisionEnter2D(Collision2D target)
	{
		IsGrounded = true;
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}

	}

}
