using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitStateMachine))]
[RequireComponent(typeof(UnitMovement))]
[RequireComponent(typeof(UnitAttack))]
[RequireComponent(typeof(UnitStatus))]
public class UnitController : MonoBehaviour
{
    private UnitStateMachine stateMachine;
    private UnitMovement movement;
    private UnitAttack attack;
    private UnitAnimation anim;
    private UnitStatus status;
    [SerializeField]
    private Transform target;

    public UnitStateMachine StateMachine => stateMachine;
    public UnitMovement Movement => movement;
    public UnitAttack Attack => attack;
    public UnitAnimation Anim => anim;
    public UnitStatus Stat => status;
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
        status = GetComponent<UnitStatus>();
    }
}
