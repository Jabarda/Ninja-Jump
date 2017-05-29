using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiplierController : MonoBehaviour {
	public static MultiplierController instance;
	// Use this for initialization
	void Start () {
		instance = this;
		
	}

	public void SetMult(int Mult)
	{
		GetComponent<Text> ().text = Mult.ToString();
		Ping ();
	}

	public void Ping()
	{
		GetComponent<Animator> ().SetTrigger ("Ping");
		GetComponent<AudioSource> ().Play ();
		Invoke ("stop", 1f);
	}

	public void stop()
	{
		GetComponent<Animator> ().SetTrigger ("idle");
	}

}
