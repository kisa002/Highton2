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

    PhotonView photonView;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            photonView = PhotonView.Get(this);
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
        }
        else
        {
            Debug.Log("Coin is not Enough");
        }
    }

    public void SendCoinPrice(int _coinPrice)
    {
        print(_coinPrice);
        photonView.RPC("OnCoinPrice", PhotonTargets.AllBuffered, _coinPrice);
    }

    [PunRPC]
    public void OnCoinPrice(int _coinPrice)
    {
        oldPirce = currentPrice;
        currentPrice = _coinPrice;

        priceList.Add(_coinPrice);

        graphRenderer.priceList = priceList;
        graphRenderer.ChangeChart();

        if (PhotonNetwork.isMasterClient)
        {
            //이벤트 실행
            EventManager.Instance.MakeEvent();
        }
    }

    public void SendCoinPriceList(string _name)
    {
        photonView.RPC("OnCoinPrice", PhotonTargets.OthersBuffered, (object)priceList, _name);
    }

    [PunRPC]
    public void OnCoinPriceList(object _priceList, string _name)
    {
        if (PhotonNetwork.isMasterClient)
            return;

        if (PlayDataManager.Instance.nickName == _name)
            priceList = (List<int>)_priceList;
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
