using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinShopPannel : MonoBehaviour
{

    public Text textCoin;
    public Text textGold;

    public int coin;

    public int work; // 1 = 구매, -1 = 판매

    public void View()
    {
        textCoin.text = coin + " 코인";
        textGold.text = coin + " 골드";
    }

    public void Hide()
    {
        coin = 0;
    }

    public void Update()
    {
        textGold.text = (coin * CoinManager.Instance.currentPrice) + " 골드";
    }

    public void AddCoin(int _value)
    {
        SoundManager.Instance.PlaySound(SoundManager.AudioType.Button2);
        coin += _value;

        if (work > 0)
            coin = Mathf.Clamp(coin, 0, CoinManager.Instance.GetAllowBuyCoin());
        else
        {
            coin = Mathf.Clamp(coin, 0, PlayDataManager.Instance.GetCoin());
        }

        textCoin.text = coin + " 코인";
    }

    public void SubCoin(int _value)
    {
        SoundManager.Instance.PlaySound(SoundManager.AudioType.Button2);
        coin -= _value;

        if (work > 0)
            coin = Mathf.Clamp(coin, 0, CoinManager.Instance.GetAllowBuyCoin());
        else
        {
            coin = Mathf.Clamp(coin, 0, PlayDataManager.Instance.GetCoin());
        }

        textCoin.text = coin + " 코인";
    }

    public void Buy()
    {
        if (coin < 1)
            return;

        SoundManager.Instance.PlaySound(SoundManager.AudioType.Buy);
        CoinManager.Instance.Buy(coin);
    }

    public void Sell()
    {
        if (coin < 1)
            return;

        SoundManager.Instance.PlaySound(SoundManager.AudioType.Sell);
        CoinManager.Instance.Sell(coin);
    }
}
