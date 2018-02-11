using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDataManager : MonoBehaviour
{
    private static PlayDataManager _instance;

    public static PlayDataManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public int gold;
    public int coin;
    public string nickName;

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

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        gold = PlayerPrefs.GetInt("Gold", 1000);
        coin = PlayerPrefs.GetInt("Coin", 0);
        nickName = PlayerPrefs.GetString("NickName", "");
    }

    public void SetNickName(string _nickName)
    {
        nickName = _nickName;
        PlayerPrefs.SetString("NickName", nickName);
    }

    public string GetNickName()
    {
        return nickName;
    }

    public int GetGold()
    {
        return gold;
    }

    public void SetGold(int _gold)
    {
        gold = _gold;
        gold = Mathf.Clamp(gold, 0, 9999999);
        PlayerPrefs.SetInt("Gold", gold);

        UIInGame.Instance.header.UpdateHeader();
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SetCoin(int _coin)
    {
        coin = _coin;
        coin = Mathf.Clamp(coin, 0, 9999999);
        PlayerPrefs.SetInt("Coin", coin);

        UIInGame.Instance.header.UpdateHeader();
    }

    public bool EnoughGold(int _gold)
    {
        if (gold - _gold < 0)
            return false;
        else
            return true;
    }

    public bool EnoughCoin(int _coin)
    {
        if (coin - _coin < 0)
            return false;
        else
            return true;
    }

    public void AddGold(int _gold)
    {
        SetGold(gold + _gold);
    }

    public void AddCoin(int _coin)
    {
        SetCoin(coin + _coin);
    }

    public string GetBuild()
    {
        return PlayerPrefs.GetString("Building", "");
    }

    public void SaveBuild(string _data)
    {
        PlayerPrefs.SetString("Building", _data);
    }

    public string GetTradeRecord()
    {
        return PlayerPrefs.GetString("TradeRecord", "");
    }

    public void SaveTradeRecord(string _data)
    {
        PlayerPrefs.SetString("TradeRecord", _data);
    }

    public int GetGPU()
    {
        return PlayerPrefs.GetInt("GPU", 0);
    }

    public void SaveGPU(int _id)
    {
        PlayerPrefs.SetInt("GPU", _id);
    }

}
