using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GPU
{
    public string name;
    public int id;
    public int price;
    public float perGetCoin;
    public Sprite sprite;

    public void SetGPU(int id, string name, int price, float perGetCoin, Sprite sprite)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.perGetCoin = perGetCoin;
        this.sprite = sprite;
    }
}