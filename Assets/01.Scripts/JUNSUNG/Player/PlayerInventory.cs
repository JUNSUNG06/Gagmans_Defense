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
    public static PlayerInventory Instance;

    private Dictionary<ItemType, List<Item>> inven = new Dictionary<ItemType, List<Item>>();
    private List<Item> equipInven = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        inven.Add(ItemType.Equipment, equipInven);
        AddItem(new Equipment(ItemType.Equipment, "InfantryHelmet", EquipmentType.Helmet));
    }

    public void AddItem(Item item)
    {
        if(item.Info != null)
        {
            if (item is Equipment)
                equipInven.Add((Equipment)item);
        }
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
                result = target.OrderBy(x => x.Info.itemName).ToList();
                break;
            case InvenSortType.None:
                result = target;
                break;
        }

        return result;
    }

    public List<Item> GetEqiuInvenByType(EquipmentType type)
    {
        List<Item> list = equipInven.FindAll(x => x.GetInfo<EquipmentSO>().equipType == type);

        foreach (var e in list)
            Debug.Log(e);

        return list;
    }
}