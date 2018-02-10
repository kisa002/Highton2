using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bill
{
    public int coin;
    public int price;

    public BillType billType;
}

public enum BillType {
    Buy,
    Sale
}
