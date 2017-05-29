using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
	public AudioClip MainMenuMusic;
	public AudioClip GamePlayMusic;
	void Awake() {
		var enemys = GameObject.FindGameObjectsWithTag ("Audio");
		foreach (var enemy in enemys) {
			//print ("HIHIHIH");
			if (enemy!=GetComponent<Transform>().gameObject) Destroy (enemy);
		}

		DontDestroyOnLoad(transform.gameObject);
	}
		
	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if (SceneManager.GetActiveScene ().name == "MainMenu") {
			GetComponent<AudioSource> ().volume = 1f;
			GetComponent<AudioSource> ().clip = MainMenuMusic;	
			GetComponent<AudioSource> ().Play ();
		}
		if (SceneManager.GetActiveScene ().name == "Spawning" && GetComponent<AudioSource> ().clip !=GamePlayMusic) {
			GetComponent<AudioSource> ().volume = 0.4f;
			GetComponent<AudioSource> ().clip = GamePlayMusic;
			GetComponent<AudioSource> ().Play ();
		}
	}
}
