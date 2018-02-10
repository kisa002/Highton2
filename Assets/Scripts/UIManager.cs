using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [SerializeField]
    GameObject panelRegister, panelEvent, panelBuildingUpgrade, panelMining, panelGPUUpgrade;

    [SerializeField]
    Button buttongGPUUpgrade;

    [SerializeField]
    Image imageGPU;

    [SerializeField]
    Text textGold, textCoin, textEventTitle, textEventContent, textEventResult, textBuildingPrice, textCurrentFloor, textNextFloor, textBuildingCant, textGPUName, textSecGold, textGPUPrice, textCurrentGPU, textNextGPU;

    PlayDataManager playDataManager;

	// Use this for initialization
	void Start () {
        playDataManager = PlayDataManager.Instance;
        

        //ShowEvent("테스트 이벤트", "스텔라 떡락 실화냐고\n제발 1000원까지만이라도 올라줘요...", "지금 스텔라 -70%인가 ㅎㅎㅎ");
        //ShowBuildingUpgrade(1000, 0);
        ShowMining("GTX 100", 1000, 1);
	}
	
	// Update is called once per frame
	void Update () {
        RefreshInfo();
	}

    private void RefreshInfo()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            textGold.text = playDataManager.GetGold().ToString();
            textCoin.text = playDataManager.GetCoin().ToString();
        }
    }

    public void ShowRegister()
    {
        panelRegister.SetActive(true);
    }

    public void CloseRegister()
    {
        panelRegister.SetActive(false);
    }

    public void ShowEvent(string title, string content, string result)
    {
        panelEvent.SetActive(true);

        textEventTitle.text = title;
        textEventContent.text = content;
        textEventResult.text = result;
    }

    public void CloseEvent()
    {
        panelEvent.SetActive(false);
    }

    public void ShowBuildingUpgrade(int requireGold, int floor)
    {
        panelBuildingUpgrade.SetActive(true);

        if (playDataManager.GetGold() < requireGold)
            textBuildingCant.gameObject.SetActive(true);
        else
            textBuildingCant.gameObject.SetActive(false);

        textBuildingPrice.text = requireGold + " 골드";
        textCurrentFloor.text = floor.ToString();
        textNextFloor.text = (floor + 1).ToString();
    }

    public void CloseBuildingUpgrade()
    {
        panelBuildingUpgrade.SetActive(false);
    }

    public void ShowMining(string gpuName, int secGold, int image)
    {
        panelMining.SetActive(true);

        textGPUName.text = gpuName;
        textSecGold.text = "초당 + " + secGold + "골드";
    }

    public void CloseMining()
    {
        panelMining.SetActive(false);
    }

    public void ShowUpgradeGPU()
    {
        //이 부분은 나중에 PlayDataManager에서 가져오는걸로
        int gpuPrice = 5000;
        int level = 1000;

        panelGPUUpgrade.SetActive(true);

        textCurrentGPU.text = "GTX " + level;
        textNextGPU.text = "GTX " + (level + 10);

        textGPUPrice.text = gpuPrice.ToString() + " 골드";
    }

    public void CloseUpgradeGPU()
    {
        panelGPUUpgrade.SetActive(false);
    }
}