using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForeground : MonoBehaviour {
	public static MovingForeground instance;
	public float speed;
	public bool move=true;
	private Vector2 offset;
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
