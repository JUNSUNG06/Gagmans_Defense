using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSOContainer : MonoBehaviour
{
    public static ItemSOContainer Instance;

    private string equipPath = "EquipSO/Equipment/";

    private Dictionary<EquipmentType, List<EquipmentSO>> equipDictionary = new Dictionary<EquipmentType, List<EquipmentSO>>();
    private Dictionary<string, IngredientSO> ingredientDictionary = new Dictionary<string, IngredientSO>();


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach(EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            equipDictionary[type] = Resources.LoadAll<EquipmentSO>($"{equipPath}{type}").ToList();
        }
    }

    public EquipmentSO GetEquipSO(EquipmentType type, string equipName)
    {
        EquipmentSO equip = equipDictionary[type].Find(x => x.itemName == equipName);

        if(equip == null)
        {
            Debug.Log("없는 아이템");
            return null;
        }    

        return equip;
    }

    public IngredientSO GetIngredientSO(string name)
    {
        return ingredientDictionary[name];
    }
}