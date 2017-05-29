using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldingMover : MonoBehaviour {
	
	public float speed;
	public bool move=true;
	private Vector2 offset;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (move == true) {
			offset = new Vector2 (0,Time.timeSinceLevelLoad * speed);
		}
		GetComponent<Renderer> ().material.mainTextureOffset = offset;

	}
}
