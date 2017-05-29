using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseButtonScript : MonoBehaviour {
	

	// Use this for initialization
	public void PauseUnpause()
	{
		Time.timeScale = 0f;
		PauseMenu.instance.ShowMenu ();
		GetComponent<AudioSource> ().Play ();
		GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource> ().Pause();
		//GameObject.FindGameObjectWithTag ("InputButton").GetComponent<RectTransform> ().position = new Vector3 (10000f, -53.6f, 53.49f);
		//GameObject.FindGameObjectWithTag ("InputButton").GetComponent<Button> ().interactable = false;
	}


}
