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
    Helmet,  //hair
    Armor,  //armor
    Back,  //back
    Weapon,  //weapon
    Shield  //weapon
}

public enum Direction
{
    None,
    Right,
    Left
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
    public ItemType type;
    public ItemSO info;

    public Item(ItemType _type, string _name)
    {
        type = _type;
    }
}

[System.Serializable]
public class Ingredient : Item
{
    public Ingredient(ItemType _type, string _name) : base(_type, _name)
    {
        info = ItemSOContainer.Instance.GetIngredientSO(_name) as IngredientSO;
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
        info = ItemSOContainer.Instance.GetEquipSO(_equipType, _name) as EquipmentSO;
        Debug.Log(info);
        rank = 1;
    }
}