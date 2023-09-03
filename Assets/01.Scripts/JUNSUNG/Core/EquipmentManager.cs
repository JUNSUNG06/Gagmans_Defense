using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    private Dictionary<EquipmentType, List<EquipmentSO>> equipDictionary = new Dictionary<EquipmentType, List<EquipmentSO>>();

    [SerializeField]
    private List<EquipList> equipList = new List<EquipList>();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach(EquipList list in equipList)
        {
            equipDictionary.Add(list.type, list.equipSOList);
        }
    }

    public EquipmentSO GetEquipSO(EquipmentType type, string equipName)
    {
        return equipDictionary[type].Find(x => x.equipName == equipName);
    }
}