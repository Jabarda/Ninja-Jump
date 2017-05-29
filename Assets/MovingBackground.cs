using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {
	public float speed;
	public bool move=true;
	private Vector2 offset;
	public static MovingBackground instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true) {
			offset = new Vector2 (Time.timeSinceLevelLoad * speed, 0);
		}
			GetComponent<Renderer> ().material.mainTextureOffset = offset;
		
	}
}
