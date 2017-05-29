using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIncresing : MonoBehaviour {
	private float buf=0;
	public static LevelIncresing instance;
	// Use this for initialization
	void Start () {
		buf = 0;
		instance = this;
	}

	public void IncLevel()
	{
		buf++;
		if (buf<70f) Spawner.instance.spawnTime = Spawner.instance.BasicTime + ((float)(buf % 120)/(float)120);
	}


}
