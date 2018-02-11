using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UICoinShop : MonoBehaviour
{
    public Text textCurrentTrade;

    public Text textCurrentPrice;
    public Text textDiffrencePrice;

    public RectTransform scrollView;
    public GameObject listSlotprefab;

    public List<string> tradeRecord;
    public List<UITradeRecordSlot> slotList;

    public UICoinShopPannel buyPannel;
    public UICoinShopPannel sellPannel;

    public UnityEvent viewBuyEvent, viewSellEvent, hideBuyEvent, hideSellEvent;

    private void Start()
    {
        ParseTradeRecord();
        UpdateListView();
    }

    void ParseTradeRecord()
    {
        string[] data = PlayDataManager.Instance.GetTradeRecord().Split('|');
        for (int i = 0; i < data.Length; ++i)
        {
            if (data[i] != "")
                tradeRecord.Add(data[i]);
        }
    }

    public void UpdateListView()
    {
        string data = "";
        for (int i = 0; i < tradeRecord.Count; ++i)
        {
            UITradeRecordSlot slot;

            if (i > slotList.Count - 1)
            {
                GameObject g = Instantiate(listSlotprefab, scrollView);
                slot = g.GetComponent<UITradeRecordSlot>();
                slotList.Add(slot);
            }
            else
            {
                slot = slotList[i];
            }
            slot.SetContent(tradeRecord[i]);
            data += tradeRecord[i] + "|";

        }
        PlayDataManager.Instance.SaveTradeRecord(data);
    }

    public void AddTradeRecord(string _tradeRecord)
    {
        tradeRecord.Add(_tradeRecord);

        if (tradeRecord.Count > 10)
            tradeRecord.RemoveAt(0);

        UpdateListView();
    }

    public void SetCurrentTrade(string _tradeRecord)
    {
        textCurrentTrade.text = _tradeRecord;
    }

    public void Update()
    {
        UpdateCurrentPrice();
        UpdateDiffrencePrice();
    }

    public void UpdateCurrentPrice()
    {
        textCurrentPrice.text = "현재 " + CoinManager.Instance.currentPrice + "G";
    }

    public void UpdateDiffrencePrice()
    {
        int d = CoinManager.Instance.GetCoinPriceDiffrent();
        if (d < 0)
            textDiffrencePrice.text = "하락 " + d + "G";
        else if (d > 0)
            textDiffrencePrice.text = "상승 +" + d + "G";
        else
            textDiffrencePrice.text = "변동 없음";

    }

    public void OnBuyOpen()
    {
        //open buy pannel
        buyPannel.View();
        viewBuyEvent.Invoke();
        SoundManager.Instance.PlaySound(SoundManager.AudioType.Button2);
    }

    public void OnSellOpen()
    {
        //open sell pannel
        sellPannel.View();
        viewSellEvent.Invoke();
        SoundManager.Instance.PlaySound(SoundManager.AudioType.Button2);
    }

    public void OnBuyHide()
    {
        //open buy pannel
        buyPannel.View();
        hideBuyEvent.Invoke();
        SoundManager.Instance.PlaySound(SoundManager.AudioType.Button2);
    }

    public void OnSellHide()
    {
        //open sell pannel
        sellPannel.View();
        hideSellEvent.Invoke();
        SoundManager.Instance.PlaySound(SoundManager.AudioType.Button2);
    }


}
