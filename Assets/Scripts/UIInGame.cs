using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    private static UIInGame _instance;

    public static UIInGame Instance
    {
        get
        {
            return _instance;
        }
    }

    public UIHeader header;

    public UICoinShop coinShop;

    public UIBuildingUpgrade buildingUpgrade;

    public UIGPUMining gpuMining;
    public UIGPUUpgrade gpuUpgrade;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
