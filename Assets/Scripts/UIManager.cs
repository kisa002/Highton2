using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [SerializeField]
    GameObject panelRegister, panelEvent, panelBuildingUpgrade;

    [SerializeField]
    Text textGold, textCoin, textEventTitle, textEventContent, textEventResult, textRequireGold, textCurrentFloor, textNextFloor, textCantBuy;

    PlayDataManager playDataManager;

	// Use this for initialization
	void Start () {
        playDataManager = PlayDataManager.Instance;

        ShowEvent("테스트 이벤트", "스텔라 떡락 실화냐고\n제발 1000원까지만이라도 올라줘요...", "지금 스텔라 -70%인가 ㅎㅎㅎ");
        ShowBuildingUpgrade(1000, 0);
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
            textCantBuy.gameObject.SetActive(true);
        else
            textCantBuy.gameObject.SetActive(false);

        textRequireGold.text = requireGold + " 골드";
        textCurrentFloor.text = floor.ToString();
        textNextFloor.text = (floor + 1).ToString();
    }

    public void CloseBuildingUpgrade()
    {
        panelBuildingUpgrade.SetActive(false);
    }
}