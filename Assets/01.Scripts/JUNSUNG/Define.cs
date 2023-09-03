using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitStateType
{
    Idle,
    Move,
    Attack,
    Stun,
    Die,
}

public enum UnitType
{
    Soldier,
    Enemy,
}

public enum StatusType
{
    AttackPower,
    AttackSpee,
    Defense,
    Health,
    CriticalProb,
    MoveSpeed,
    HealthRecovery,
}

public enum EquipmentType
{
    Helmet,
    Cloths,
    Pants,
    Armor,
    Back,
    Weapon, 
}

[System.Serializable]
public class Status
{
    public StatusType Type;
    [Range(0, 5)]
    public int Value;
}

[System.Serializable]
public class EquipList
{
    public EquipmentType type;
    public List<EquipmentSO> equipSOList;
}

[System.Serializable]
public class Equipment
{
    private EquipmentSO info;
    public EquipmentSO Info => info;

    public Equipment(EquipmentType type, string name)
    {
        info = EquipmentManager.Instance.GetEquipSO(type, name);
    }
}