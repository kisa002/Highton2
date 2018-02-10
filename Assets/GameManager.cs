using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

	public enum SceneFormat {
		GraphScene = -1,
		BuildingScene = 0,
		MiningScene = 1
	}
	public SceneFormat sceneFormat;

	void Awake()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);    

		DontDestroyOnLoad(gameObject);
	}
}
