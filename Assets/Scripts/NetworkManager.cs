using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    private SocketIOComponent socket;

    void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            socket = GetComponent<SocketIOComponent>();
        }
    }

    void Start()
    {
        socket.On("CoinPrice", OnCoinPrice);
        socket.On("CoinPriceList", OnCoinPriceList);
        socket.On("PriceChange", OnChangePrice);
        socket.On("Event", OnEvent);
    }


    public void SendCoinPrice(int _coin, int _coinPrice, int _work)
    {
        JSONObject json = new JSONObject(JSONObject.Type.OBJECT);
        json.AddField("Name", PlayDataManager.Instance.nickName);
        json.AddField("Coin", _coin);
        json.AddField("Price", _coinPrice);
        json.AddField("Work", _work);

        socket.Emit("CoinPrice", json);
    }

    public void OnCoinPrice(SocketIOEvent e)
    {
        JSONObject json = e.data;
        string name = json.GetField("Name").str;
        int work = (int)json.GetField("Work").f;
        int price = (int)json.GetField("Price").f;
        int coin = (int)json.GetField("Coin").f;

        if (work == -1)
        {
            UIInGame.Instance.coinShop.SetCurrentTrade(name + "님이" + coin + "코인을 " + price + "골드에 판매");
        }
        else
        {
            UIInGame.Instance.coinShop.SetCurrentTrade(name + "님이" + coin + "코인을 " + price + "골드에 구입");
        }

        CoinManager.Instance.OnCoinPrice(price);

    }

    public void OnCoinPriceList(SocketIOEvent e)
    {
        LitJson.JsonData json = LitJson.JsonMapper.ToObject(e.data.ToString());
        List<int> priceList = new List<int>();
        for (int i = 0; i < json["PriceList"].Count; ++i)
        {
            int price = int.Parse(json["PriceList"][i]["Price"].ToString());
            priceList.Add(price);
        }

        CoinManager.Instance.OnCoinPriceList(priceList);
    }

    public void OnChangePrice(SocketIOEvent e)
    {
        JSONObject json = e.data;

        CoinManager.Instance.OnChangePrice((int)json.GetField("OldPrice").f, (int)json.GetField("CurrentPrice").f);
    }

    public void OnEvent(SocketIOEvent e)
    {
        JSONObject json = e.data;

        int index = (int)json.GetField("Event").f;

        EventManager.Instance.MakeEvent(index);
    }

}
