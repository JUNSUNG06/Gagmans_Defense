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

public enum ItemType
{
    Equipment,
    Ingredient
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
public class Item
{
    public string name;
    public ItemType type;
    public Sprite image;

    public Item(ItemType _type, string _name)
    {
        type = _type;
        name = _name;
    }
}

[System.Serializable]
public class Ingredient : Item
{
    public Ingredient(ItemType _type, string _name) : base(_type, _name)
    {

    }
}

[System.Serializable]
public class Equipment : Item
{
    private int rank;
    public int Rank => rank;
    public EquipmentType equipType;

    public Equipment(ItemType _type, string _name, EquipmentType _equipType) : base(_type, _name)
    {
        equipType = _equipType;
    }
}

//[System.Serializable]
//public class Equipment
//{
//    public string equipName;
//    public Sprite sprite;
//    public StatusSO status;
//    public EquipmentType type;

//    public Equipment(EquipmentType type, string name)
//    {
//        EquipmentSO info = EquipmentManager.Instance.GetEquipSO(type, name);

//        equipName = info.equipName;
//        sprite = info.sprite;
//        status = info.status;
//        this.type = info.type;
//    }
//}