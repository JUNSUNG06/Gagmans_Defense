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

[System.Serializable]
public class Status
{
    public StatusType Type;
    public float Value;
}