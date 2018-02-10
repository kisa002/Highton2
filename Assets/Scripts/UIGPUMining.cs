using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGPUMining : MonoBehaviour
{
    public Image imageGPU;

    public Button buttongGPUUpgrade;

    public Text textGPUName, textSecGold;

    private PlayDataManager playDataManager;
    private GPUMiningManager gpuMiningManager;

    private void Start()
    {
        playDataManager = PlayDataManager.Instance;
        gpuMiningManager = GPUMiningManager.Instance;
    }

    public void SetGPU(GPU gpu)
    {
        textGPUName.text = gpu.name;
        textSecGold.text = "초당 + " + gpu.perGetCoin + "골드";
        imageGPU.sprite = gpu.sprite;
    }

    public void ShowGPUUpgrade()
    {
		SoundManager.Instance.PlaySound (SoundManager.AudioType.Button2);
        UIInGame.Instance.gpuUpgrade.View();
    }
}
