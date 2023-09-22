using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(UnitStateMachine))]
[RequireComponent(typeof(UnitMovement))]
[RequireComponent(typeof(UnitAttack))]
[RequireComponent(typeof(UnitStatus))]
[RequireComponent(typeof(UnitHealth))]
[RequireComponent(typeof(UnitEquipment))]

public class UnitController : MonoBehaviour
{
    private UnitStateMachine stateMachine;
    private UnitMovement movement;
    private UnitAttack attack;
    private UnitAnimation anim;
    private UnitStatus status;
    private UnitHealth health;
    private UnitEquipment equipment;
    private SPUM_SpriteList spriteList;
    [SerializeField]
    private Transform target;

    public UnitStateMachine StateMachine => stateMachine;
    public UnitMovement Movement => movement;
    public UnitAttack Attack => attack;
    public UnitAnimation Anim => anim;
    public UnitStatus Stat => status;
    public UnitHealth Health => health;
    public UnitEquipment Equipment => equipment;
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

    public void Init()
    {
        stateMachine = GetComponent<UnitStateMachine>();
        stateMachine.Init(this);
        movement = GetComponent<UnitMovement>();
        movement.Init(this);
        attack = GetComponent<UnitAttack>();
        attack.Init(this);
        anim = transform.Find("Visual/UnitRoot").AddComponent<UnitAnimation>();
        anim.Init(this);
        status = GetComponent<UnitStatus>();
        status.Init(this);
        health = GetComponent<UnitHealth>();
        health.Init(this);
        equipment = GetComponent<UnitEquipment>();
        equipment.Init(this);
        spriteList = transform.Find("Visual/UnitRoot/Root").GetComponent<SPUM_SpriteList>();
        spriteList.Init(this);
    }
}
