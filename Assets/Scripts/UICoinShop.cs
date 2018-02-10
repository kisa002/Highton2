﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinShop : MonoBehaviour
{
    public Text currentTrade;

    public RectTransform scrollView;
    public GameObject listSlotprefab;

    public List<string> tradeRecord;
    public List<UITradeRecordSlot> slotList;

    public void UpdateListView()
    {
        for (int i = 0; i < tradeRecord.Count; ++i)
        {
            UITradeRecordSlot slot;

            if (i > tradeRecord.Count - 1)
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
        currentTrade.text = _tradeRecord;
    }

    public void OnBuyOpen() {
        //open buy pannel
    }

    public void OnSellOpen() {
        //open sell pannel
    }
}