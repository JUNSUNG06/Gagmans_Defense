using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StartingEquip
{
    public EquipmentType type;
    public string name;
}

[CreateAssetMenu(menuName = "SO/UnitSO")]
public class UnitSO : ScriptableObject
{
    public int unitCost;
    public UnitType unitType;
    public string unitName;
    public GameObject unit;
    public UnitController controller;
    public StatusSO status;
    public List<EquipmentSO> startingEquips = new List<EquipmentSO>();
    public RuntimeAnimatorController animator;
}
