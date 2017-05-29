using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desctroyer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D target)
	{
		Destroy (target.gameObject);

	}
}
