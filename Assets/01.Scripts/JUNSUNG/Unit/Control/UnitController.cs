using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitStateMachine))]
[RequireComponent(typeof(UnitMovement))]
[RequireComponent(typeof(UnitAttack))]
[RequireComponent(typeof(UnitStatus))]
[RequireComponent(typeof(UnitHealth))]
[RequireComponent(typeof(UnitAnimation))]
public class UnitController : MonoBehaviour
{
    private UnitStateMachine stateMachine;
    private UnitMovement movement;
    private UnitAttack attack;
    private UnitAnimation anim;
    private UnitStatus status;
    private UnitHealth health;
    [SerializeField]
    private Transform target;

    public UnitStateMachine StateMachine => stateMachine;
    public UnitMovement Movement => movement;
    public UnitAttack Attack => attack;
    public UnitAnimation Anim => anim;
    public UnitStatus Stat => status;
    public UnitHealth Health => health;
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
        stateMachine.Init();
        movement = GetComponent<UnitMovement>();
        movement.Init();
        attack = GetComponent<UnitAttack>();
        attack.Init();
        anim = GetComponent<UnitAnimation>();
        anim.Init();
        status = GetComponent<UnitStatus>();
        status.Init();
        health = GetComponent<UnitHealth>();
        health.Init();

        //나중에 지우셈

        Debug.Log(GameObject.Find("TestEnemy").transform);
        Target = GameObject.Find("TestEnemy").transform;
    }
}
