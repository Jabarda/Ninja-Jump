using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartBlink : MonoBehaviour {
	private float ticker = 0;
	public float BlinkSpeed =0.5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		ticker += Time.deltaTime;
		if (ticker % (BlinkSpeed*2) < BlinkSpeed)
			GetComponent<CanvasGroup> ().alpha = 0;
		else
			GetComponent<CanvasGroup> ().alpha = 1;
	}
}
