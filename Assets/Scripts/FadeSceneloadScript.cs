using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class FadeSceneloadScript: MonoBehaviour {
	public static FadeSceneloadScript instance;
	public bool NeedToLoad=true;
	Animator anim;
	bool IsFading = false;
	// Use this for initialization
	IEnumerator Start () {
		instance = this;
		anim = GetComponent<Animator> ();
		if (NeedToLoad)
			yield return StartCoroutine(FadeToBlack ());
		//else 
			//anim.SetTrigger ("Idle");
	}
		

	public IEnumerator FadeToClear(string NextScene){
		//if (SceneManager.GetActiveScene().name=="MainMenu") GameObject.FindGameObjectWithTag ("FaderCanvas").GetComponent<Canvas> ().sortingLayerName = "Characters";
		GameObject.FindGameObjectWithTag ("FaderCanvas").transform.position = new Vector3 (0, 0, 1);
		IsFading = true;
		print ("FadeToClear");
		anim.SetTrigger ("FadeIn");
		while (IsFading)
			yield return null;
		print ("GoNext");
		SceneManager.LoadScene (NextScene);
	}

	public IEnumerator FadeToBlack(){
		IsFading = true;
		print ("FadeToBlack");
		anim.SetTrigger ("FadeOut");
		while (IsFading)
			yield return null;
		anim.SetTrigger ("Idle");
		GameObject.FindGameObjectWithTag ("FaderCanvas").transform.position = new Vector3 (30, 0, 1);
	}

	void AnimationComplete()
	{
		IsFading = false;
	}
}
