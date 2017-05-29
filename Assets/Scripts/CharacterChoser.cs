using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterChoser : MonoBehaviour {
	public static CharacterChoser instance;

	public RuntimeAnimatorController Ninja;
	public RuntimeAnimatorController Pirate;
	public RuntimeAnimatorController Maiden;
	public RuntimeAnimatorController Ranger;
	public RuntimeAnimatorController Samurai;
	public RuntimeAnimatorController Spy;

	public Sprite Parashute_Ninja;
	public Sprite Parashute_Pirate;
	public Sprite Parashute_Maiden;
	public Sprite Parashute_Ranger;
	public Sprite Parashute_Samurai;
	public Sprite Parashute_Spy;

	private string CurrentCharacter;

	void Awake() {

		DontDestroyOnLoad(transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("CharacterChoser");
		if (enemys.GetLength (0) != 1)
			Destroy (transform.gameObject);
		instance = this;
		SceneManager.sceneLoaded += OnSceneLoaded;
		if (!PlayerPrefs.HasKey ("Money"))
			PlayerPrefs.SetInt ("Money", 0);

		PlayerPrefs.SetInt ("Ninja", 1);
		if (!PlayerPrefs.HasKey ("Character"))
			PlayerPrefs.SetString ("Character", "Ninja");
		if (!PlayerPrefs.HasKey (PlayerPrefs.GetString ("Character"))) PlayerPrefs.SetString ("Character","Ninja");

		CurrentCharacter = PlayerPrefs.GetString ("Character");
		//Для каждой кнопки ставим её корректное состояние (открыт герой или нет)
		GameObject[] Buttons = GameObject.FindGameObjectsWithTag ("SelectButton");
		foreach (GameObject button in Buttons) {
			button.GetComponent<CharacterChooserButtonController> ().SetBlockUnblock ();
			button.GetComponent<CharacterChooserButtonController> ().ChooseByName (CurrentCharacter);
		}

	}
	

	public void SetPlayer(string name)
	{
		CurrentCharacter = name;
		PlayerPrefs.SetString ("Character", CurrentCharacter);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Spawning") {
			if (CurrentCharacter == "Ninja") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Ninja;
				GameObject.FindGameObjectWithTag ("Parashute").GetComponent<SpriteRenderer> ().sprite = Parashute_Ninja;
			}
			if (CurrentCharacter == "Pirate") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Pirate;
				GameObject.FindGameObjectWithTag ("Parashute").GetComponent<SpriteRenderer> ().sprite = Parashute_Pirate;
			}
			if (CurrentCharacter == "Spy") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Spy;
				GameObject.FindGameObjectWithTag ("Parashute").GetComponent<SpriteRenderer> ().sprite = Parashute_Spy;
			}
			if (CurrentCharacter == "Maiden") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Maiden;
				GameObject.FindGameObjectWithTag ("Parashute").GetComponent<SpriteRenderer> ().sprite = Parashute_Maiden;
			}
			if (CurrentCharacter == "Samurai") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Samurai;
				GameObject.FindGameObjectWithTag ("Parashute").GetComponent<SpriteRenderer> ().sprite = Parashute_Samurai;
			}
			if (CurrentCharacter == "Ranger") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Ranger;
				GameObject.FindGameObjectWithTag ("Parashute").GetComponent<SpriteRenderer> ().sprite = Parashute_Ranger;
			}
		}
		if (scene.name == "main") {
			if (CurrentCharacter == "Ninja") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Ninja;
			}
			if (CurrentCharacter == "Pirate") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Pirate;
			}
			if (CurrentCharacter == "Spy") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Spy;
			}
			if (CurrentCharacter == "Maiden") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Maiden;
			}
			if (CurrentCharacter == "Samurai") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Samurai;
			}
			if (CurrentCharacter == "Ranger") {
				GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().runtimeAnimatorController = Ranger;
			}
			GameObject.FindGameObjectWithTag ("Gamer").GetComponent<Animator> ().SetTrigger ("Running_Right");
		}
	}
}
