using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;

    public static CoinManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public GraphRenderer graphRenderer;

    public List<int> priceList;

    public int oldPirce = 0, currentPrice = 0;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    //구매
    public void Buy(int coin)
    {
        int coinPrice = coin * currentPrice;
        if (PlayDataManager.Instance.EnoughGold(coinPrice))
        {
            PlayDataManager.Instance.AddGold(-coinPrice);
            PlayDataManager.Instance.AddCoin(coin);
            SendCoinPrice(coin, coinPrice, 1);
        }
        else
        {
            Debug.Log("Gold is not Enough");
        }
    }

    //판매
    public void Sell(int coin)
    {
        int coinPrice = coin * currentPrice;
        if (PlayDataManager.Instance.EnoughCoin(coin))
        {
            PlayDataManager.Instance.AddGold(coinPrice);
            PlayDataManager.Instance.AddCoin(-coin);
            SendCoinPrice(coin, coinPrice, -1);
        }
        else
        {
            Debug.Log("Coin is not Enough");
        }
    }

    public void SendCoinPrice(int _coin, int _coinPrice, int _work)
    {
        NetworkManager.instance.SendCoinPrice(_coin, _coinPrice, _work);
    }

    public void OnCoinPrice(int _coinPrice)
    {
        priceList.Add(_coinPrice);

        graphRenderer.priceList = priceList;
        graphRenderer.ChangeChart();
    }

    public void OnChangePrice(int _oldPirce, int _currnetPirce)
    {
        oldPirce = _oldPirce;
        currentPrice = _currnetPirce;
    }

    public void OnCoinPriceList(List<int> _priceList)
    {
        graphRenderer.priceList = priceList = _priceList;
        graphRenderer.ChangeChart();
    }


    public int GetAllowBuyCoin()
    {
        return PlayDataManager.Instance.GetGold() / currentPrice;
    }

    public int GetCoinPriceDiffrent()
    {
        return currentPrice - oldPirce;
    }

}
