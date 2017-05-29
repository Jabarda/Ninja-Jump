using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Tutorial"))
			Destroy (gameObject);
		else
			PlayerPrefs.SetInt ("Tutorial", 1);
	}
	

}
