using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int money;
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
        }
    }
}
