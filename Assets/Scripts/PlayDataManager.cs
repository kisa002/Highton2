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
        
    }

    public void LoadData() {
        gold = PlayerPrefs.GetInt("Gold", 0);
        coin = PlayerPrefs.GetInt("Coin", 0);
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



}
