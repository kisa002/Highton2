using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UICoinShop : MonoBehaviour
{
    public Text textCurrentTrade;

    public RectTransform scrollView;
    public GameObject listSlotprefab;

    public List<string> tradeRecord;
    public List<UITradeRecordSlot> slotList;

    public UICoinShopPannel buyPannel;
    public UICoinShopPannel sellPannel;

	public UnityEvent viewBuyEvent, viewSellEvent, hideBuyEvent, hideSellEvent;

    private void Start()
    {
        UpdateListView();
    }

    public void UpdateListView()
    {
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
        }
    }

    public void AddTradeRecord(string _tradeRecord)
    {
        tradeRecord.Add(_tradeRecord);
    }

    public void SetCurrentTrade(string _tradeRecord)
    {
        textCurrentTrade.text = _tradeRecord;
    }

    public void OnBuyOpen()
    {
		//open buy pannel
        buyPannel.View();
		viewBuyEvent.Invoke();
    }

    public void OnSellOpen()
    {
        //open sell pannel
        sellPannel.View();
		viewSellEvent.Invoke ();
    }

	public void OnBuyHide()
	{
		//open buy pannel
		buyPannel.View();
		hideBuyEvent.Invoke();
	}

	public void OnSellHide()
	{
		//open sell pannel
		sellPannel.View();
		hideSellEvent.Invoke ();
	}


}
