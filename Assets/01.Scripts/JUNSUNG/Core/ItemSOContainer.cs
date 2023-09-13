using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSOContainer : MonoBehaviour
{
    public static ItemSOContainer Instance;

    private Dictionary<EquipmentType, List<EquipmentSO>> equipDictionary = new Dictionary<EquipmentType, List<EquipmentSO>>();
    private Dictionary<string, IngredientSO> ingredientDictionary = new Dictionary<string, IngredientSO>();

    [SerializeField]
    private List<EquipList> equipList = new List<EquipList>();
    [SerializeField]
    private List<IngredientSO> ingerdientList = new List<IngredientSO>();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach(EquipList v in equipList)
        {
            equipDictionary[v.type] = v.equipSOList;
        }

        foreach(IngredientSO v in ingerdientList)
        {
            ingredientDictionary[v.itemName] = v;
        }
    }

    public EquipmentSO GetEquipSO(EquipmentType type, string equipName)
    {
        return equipDictionary[type].Find(x => x.itemName == equipName);
    }

    public IngredientSO GetIngredientSO(string name)
    {
        return ingredientDictionary[name];
    }
}