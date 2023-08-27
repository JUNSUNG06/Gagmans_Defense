using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Soldier,
    Enemy,
}


[RequireComponent(typeof(UnitStateMachine))]
[RequireComponent(typeof(UnitMovement))]
[RequireComponent(typeof(UnitAttack))]
public class UnitController : MonoBehaviour
{
    private UnitStateMachine stateMachine;
    private UnitMovement movement;
    private UnitAttack attack;
    private UnitAnimation anim;
    [SerializeField]
    private Transform target;

    public UnitStateMachine StateMachine => stateMachine;
    public UnitMovement Movement => movement;
    public UnitAttack Attack => attack;
    public UnitAnimation Anim => anim;
    public Transform Target 
    { 
        get => target; 
        set
        {
            target = value;

            if(target != null)
                Movement.SetTargetPos(target.position);
        }
    }

    public UnitType Type;

    private void Awake()
    {
        stateMachine = GetComponent<UnitStateMachine>();
        movement = GetComponent<UnitMovement>();
        attack = GetComponent<UnitAttack>();
        anim = GetComponent<UnitAnimation>();
    }
}
