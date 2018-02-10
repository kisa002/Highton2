using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum SceneFormat
    {
        GraphScene = -1,
        BuildingScene = 0,
        MiningScene = 1
    }
    public SceneFormat sceneFormat;

    public UIInGame ui;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
