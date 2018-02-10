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
            SendCoinPrice(coinPrice + (int)Random.Range(coinPrice * 0.01f, coinPrice * 0.1f));
            //이벤트 매니저 실행

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
            SendCoinPrice(coinPrice - (int)Random.Range(coinPrice * 0.01f, coinPrice * 0.1f));
            //이벤트 매니저 실행

        }
        else
        {
            Debug.Log("Coin is not Enough");
        }
    }

    public void SendCoinPrice(int _coinPrice)
    {
        print(_coinPrice);
        OnCoinPrice(_coinPrice);
    }

    //[PunRPC]
    public void OnCoinPrice(int _coinPrice)
    {
        oldPirce = currentPrice;
        currentPrice = _coinPrice;

        priceList.Add(_coinPrice);

        graphRenderer.priceList = priceList;
        graphRenderer.ChangeChart();
    }

    public int GetCoinPriceDiffrent()
    {
        return currentPrice - oldPirce;
    }

}
