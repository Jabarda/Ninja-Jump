using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterChooserButtonController : MonoBehaviour {
	public Color ColorBackground;
	public string CharacterName;
	public GameObject children;
	// Use this for initialization
	void Start () {
		
	}
	//разблокировать/заблокировать кнопку
	public void SetBlockUnblock()
	{
		if (PlayerPrefs.HasKey (CharacterName)) {
			children.GetComponent<SpriteRenderer> ().color = Color.white;
			GetComponent<Image> ().color = ColorBackground;
			GetComponent<Image> ().fillCenter = true;
		}
		else {
			children.GetComponent<SpriteRenderer> ().color = Color.black;
			Color buf = Color.black;
			buf.a = 0.5f;
			GetComponent<Image> ().color = Color.black;
			GetComponent<Image> ().color = buf;
			GetComponent<Image> ().fillCenter = true;
		}
	}

	public void ChooseByName(string s)
	{
		if (CharacterName == s)
			chooseHero ();
	}
	//снять выделение с кнопки
	public void unselect()
	{
		gameObject.GetComponent<Animator> ().SetTrigger ("Unselect");
		children.GetComponent<Animator> ().SetTrigger ("idle");
	}

	public void chooseHero()
	{
		
		GameObject[] Buttons = GameObject.FindGameObjectsWithTag ("SelectButton");
		foreach (GameObject button in Buttons)
			if (gameObject!= button) button.GetComponent<CharacterChooserButtonController> ().unselect ();
		gameObject.GetComponent<Animator> ().SetTrigger ("Select");
		children.GetComponent<Animator> ().SetTrigger ("Running_Right");
		//if (!PlayerPrefs.HasKey (CharacterName))
		GameObject.FindGameObjectWithTag ("ChoseButton").GetComponent<CharacterManager> ().SetCurrentName (CharacterName);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
