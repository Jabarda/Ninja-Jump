using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour {
	bool IsIncreased = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D Target){
		if (Target.gameObject.name=="Ninja")
			if (GetComponent<Transform> ().position.x < -5.25f && IsIncreased == false) {
				IsIncreased = true;
				ScoreManager.instance.CurrentScore++;
			};
	}
}
