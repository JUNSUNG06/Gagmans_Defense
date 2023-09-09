using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<ItemType, ItemSO> itemDictionary = new Dictionary<ItemType, ItemSO>();

    public void GetItem(ItemType type)
    {
        if(!itemDictionary.ContainsKey(type))
        {

        }
    }
}
