using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour {
	public static ReadyManager instance;
	private float ticker = 0;
	public float BlinkSpeed =0.5f;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	// Update is called once per frame
	void Update () {
		ticker += Time.deltaTime;
		if (ticker < 4)
		if (ticker % (BlinkSpeed * 2) < BlinkSpeed)
			GetComponent<CanvasGroup> ().alpha = 0;
		else
			GetComponent<CanvasGroup> ().alpha = 1;
		else {
			GetComponent<CanvasGroup> ().alpha = 1;
			GetComponent<Text> ().text = "GO";
		}

	}

	public void SetText(string s)
	{
		//GetComponent<Text> ().text = s;
	}
		
}
