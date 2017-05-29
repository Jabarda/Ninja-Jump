using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAchievements : MonoBehaviour {
	Transform transformer;
	// Use this for initialization
	void Start () {
		transformer = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transformer.position.y >= 8f)
			GooglePlayManager.instance.UnlockAchi ("Big jump");
		if (transformer.position.x <= -9f)
			GooglePlayManager.instance.UnlockAchi ("Left_dissapear");
		if (transformer.position.y >= 7f && GetComponent<Controller> ().isDead)
			GooglePlayManager.instance.UnlockAchi ("Heaven");
	}
}
