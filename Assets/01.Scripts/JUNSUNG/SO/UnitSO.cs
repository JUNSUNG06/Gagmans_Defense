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
    public UnitType unitType;
    public string unitName;
    public GameObject unit;
    public StatusSO status;
    public List<StartingEquip> startingEquips = new List<StartingEquip>();
    public RuntimeAnimatorController animator;
}
