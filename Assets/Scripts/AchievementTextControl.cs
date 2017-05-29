using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementTextControl : MonoBehaviour {
	public void SetText(string s)
	{
		GameObject.FindGameObjectWithTag("Achievement text").GetComponent<Text>().text = s;
		AchievementMoving.instance.GetComponent<AchievementMoving> ().show ();
	}

}
