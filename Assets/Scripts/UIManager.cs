using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [SerializeField]
    GameObject panelRegister, panelEvent;

    [SerializeField]
    Text textGold, textCoin, textEventTitle, textEventContent, textEventResult;

    PlayDataManager playDataManager;

	// Use this for initialization
	void Start () {
        playDataManager = PlayDataManager.Instance;

        ShowEvent("테스트 이벤트", "스텔라 떡락 실화냐고\n제발 1000원까지만이라도 올라줘요...", "지금 스텔라 -70%인가 ㅎㅎㅎ");
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
}