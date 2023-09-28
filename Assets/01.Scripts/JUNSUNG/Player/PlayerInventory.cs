using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public enum InvenSortType
{
    Name,
    None
}


public class PlayerInventory : MonoBehaviour
{
    private Dictionary<ItemType, List<Item>> inven = new Dictionary<ItemType, List<Item>>();
    private List<Item> equipInven = new List<Item>();

    private void Start()
    {
        inven.Add(ItemType.Equipment, equipInven);
        AddItem(new Equipment(ItemType.Equipment, "Test_Helmet", EquipmentType.Helmet));
    }

    public void AddItem(Item item)
    {
        if(item is Equipment)
            equipInven.Add((Equipment)item);
    }

    public void RemoveItem(Item item)
    {
        try
        {
            equipInven.Remove(equipInven.Find(x => x == item));
        }
        catch(NullReferenceException ex)
        {
            Debug.Log($"{ex.Message} / 삭제하려는 아이템 인벤에 없음");
        }
    }

    public List<Item> GetSortInven(ItemType itemtype, InvenSortType sortType)
    {
        List<Item> target = inven[itemtype];
        List<Item> result = null;

        switch (sortType)
        {
            case InvenSortType.Name:
                result = equipInven.OrderBy(x => x.Info.itemName).ToList();
                break;
            case InvenSortType.None:
                result = equipInven;
                break;
        }

        return result;
    }
}