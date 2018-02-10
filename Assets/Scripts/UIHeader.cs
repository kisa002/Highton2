using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeader : MonoBehaviour
{
    public Text textGold, textCoin;

    private void Start()
    {
        UpdateHeader();
    }

    public void UpdateHeader()
    {
        textGold.text = PlayDataManager.Instance.GetGold() + "<color=yellow>G</color>";
        textCoin.text = PlayDataManager.Instance.GetCoin() + "<color=yellow>C</color>";
    }
}
