using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinShopPannel : MonoBehaviour
{

    public Text textCoin;
    public Text textGold;

    public int coin;

    public void View()
    {
        textCoin.text = textGold.text = coin.ToString();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        coin = 0;
        gameObject.SetActive(false);
    }

    public void AddCoin(int _value)
    {
        coin += _value;
        coin = Mathf.Clamp(coin, 0, CoinManager.Instance.GetAllowBuyCoin());
    }

    public void SubCoin(int _value)
    {
        coin -= _value;
        coin = Mathf.Clamp(coin, 0, CoinManager.Instance.GetAllowBuyCoin());
    }

    public void Buy()
    {
        CoinManager.Instance.Buy(coin);
    }

    public void Sell()
    {
        CoinManager.Instance.Sell(coin);
    }
}
