using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnJumpBugFix : MonoBehaviour {
	Vector3 backup;
	// Use this for initialization
	void Start () {
		print ("HI");
		backup = GameObject.FindGameObjectWithTag ("InputButton").transform.position;
		GameObject.FindGameObjectWithTag ("InputButton").transform.position = new Vector3 (100f, 100f,0);
		Invoke ("Beg", 0.2f);
	}

	void Beg()
	{
		print ("HI");
		GameObject.FindGameObjectWithTag ("InputButton").transform.position = backup;
	}

}
