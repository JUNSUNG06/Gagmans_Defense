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
[RequireComponent(typeof(UnitPassive))]

public class UnitController : MonoBehaviour
{
    private UnitStateMachine stateMachine;
    private UnitMovement movement;
    private UnitAttack attack;
    private UnitAnimation anim;
    private UnitStatus status;
    private UnitHealth health;
    private UnitEquipment equipment;
    private UnitPassive passive;
    
    [SerializeField]
    private Transform target;

    public UnitSO info;
    public UnitStateMachine StateMachine => stateMachine;
    public UnitMovement Movement => movement;
    public UnitAttack Attack => attack;
    public UnitAnimation Anim => anim;
    public UnitStatus Stat => status;
    public UnitHealth Health => health;
    public UnitEquipment Equipment => equipment;
    public UnitPassive Passive => passive;
    public Transform Target 
    { 
        get => target; 
        set
        {
            target = value;

            if (target != null)
                Movement.SetTargetPos(target.position);
            else
                movement.Stop();
        }
    }

    public virtual void Init(UnitSO info, Transform target)
    {
        this.info = info;

        stateMachine = GetComponent<UnitStateMachine>();
        stateMachine.Init(this);
        
        movement = GetComponent<UnitMovement>();
        movement.Init(this);
        
        attack = GetComponent<UnitAttack>();
        attack.Init(this);
        
        anim = transform.Find("Visual/UnitRoot").AddComponent<UnitAnimation>();
        anim.Init(this, info.animator);
        
        status = GetComponent<UnitStatus>();
        status.Init(this);

        health = GetComponent<UnitHealth>();
        health.Init(this);

        equipment = GetComponent<UnitEquipment>();
        equipment.Init(this);

        passive = GetComponent<UnitPassive>();
        passive.Init(this);

        Target = target;
    }
}
