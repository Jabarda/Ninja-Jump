using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaBackground : MonoBehaviour {
	public GameObject Ninja;
	public float minSpeed=1f;
	public float delta=100f;
	public float minTimeSpawn=0.1f;
	public float maxTimeSpawn=0.5f;
	public float minScale=0.5f;
	public float maxScale=0.9f;
	// Use this for initialization
	void Start () {
		GetComponent<Transform> ().position = new Vector3 (Random.Range (-8f, 8f), 7f, 0f);
		GetComponent<Transform> ().localScale = new Vector2 (1f, 1f) * Random.Range (minScale, maxScale);
		GetComponent<Rigidbody2D> ().gravityScale = 0f;
		GetComponent<Rigidbody2D> ().AddForce(new Vector2(0f, -1 * Random.Range (minSpeed, minSpeed + delta)));
		Invoke("MakeNewOne",Random.Range(minTimeSpawn,maxTimeSpawn));
	}
	
	void MakeNewOne() {
		Instantiate (Ninja);
	}

	// Update is called once per frame
	void Update () {
		if (GetComponent<Transform> ().position.y < -7f)
			Destroy (this.gameObject);
	}
}
