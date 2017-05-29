using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadForLoadScriptMainMenu : MonoBehaviour {
	public static SceneLoadForLoadScriptMainMenu instance;
	public bool NeedToLoad=true;
	AsyncOperation op;
	Animator anim;
	bool IsFading = false;
	// Use this for initialization
	IEnumerator Start () {
		instance = this;
		anim = GetComponent<Animator> ();
		yield return StartCoroutine(FadeToBlack ());
		print ("hello");
		op = SceneManager.LoadSceneAsync("MainMenu");
		op.allowSceneActivation = false;
		print ("hello");
		StartCoroutine (WaitForLoad ());
		yield return op;

		
	}

	public IEnumerator WaitForLoad()
	{
		while (op.progress != 0.9f) {
			print (op.progress);
			yield return null;
		}
		print ("hello");
		StartCoroutine (FadeToClear());
	}
	public IEnumerator FadeToClear(){

		IsFading = true;
		print ("FadeToClear");
		anim.SetTrigger ("FadeIn");
		while (IsFading)
			yield return null;
		print ("GoNext");
		op.allowSceneActivation = true;
	}

	public IEnumerator FadeToBlack(){
		IsFading = true;
		print ("FadeToBlack");
		anim.SetTrigger ("FadeOut");
		while (IsFading)
			yield return null;
		anim.SetTrigger ("Idle");
	}

	void AnimationComplete()
	{
		IsFading = false;
	}
	// Update is called once per frame
	void Update () {
		
		
	}
}
