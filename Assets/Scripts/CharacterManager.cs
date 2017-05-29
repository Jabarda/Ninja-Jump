using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {
	string CurrentName;
	int CurrentPrice;
	Dictionary<string,int> PriceManager = new Dictionary<string, int>();
	public int SpyPrice;
	public int MaidenPrice;
	public int SamuraiPrice;
	public int RangerPrice;
	public int PiratePrice;
	// Use this for initialization
	void Start () {
		PriceManager.Add ("Spy", SpyPrice);
		PriceManager.Add ("Maiden", MaidenPrice);
		PriceManager.Add ("Samurai", SamuraiPrice);
		PriceManager.Add ("Ranger", RangerPrice);
		PriceManager.Add ("Pirate", PiratePrice);
	}

	public void SetCurrentName(string name)
	{
		CurrentName = name;
		PriceManager.TryGetValue (name, out CurrentPrice);
		if (PlayerPrefs.HasKey (name))
			GetComponentInChildren<Text> ().text = "Start";
		else {
			GetComponentInChildren<Text> ().text = "Unlock\n" + CurrentPrice;
		}
	}

	//нажатие на кнопку подтвердить/купить
	public void click()
	{
		if (!PlayerPrefs.HasKey (CurrentName)) {
			if (PlayerPrefs.GetInt ("Money") >= CurrentPrice) {
				PlayerPrefs.SetInt (CurrentName, 1);
				GooglePlayManager.instance.UnlockAchi (CurrentName);
				PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - CurrentPrice);
				GameObject[] Buttons = GameObject.FindGameObjectsWithTag ("SelectButton");
				foreach (GameObject button in Buttons) 
					button.GetComponent<CharacterChooserButtonController> ().SetBlockUnblock ();
				SetCurrentName (CurrentName);
			}
		} else {
			CharacterChoser.instance.SetPlayer (CurrentName);
			StartCoroutine(FadeSceneloadScript.instance.FadeToClear("Spawning"));
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
