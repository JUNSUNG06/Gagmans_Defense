using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitStateMachine))]
[RequireComponent(typeof(UnitMovement))]
public class UnitController : MonoBehaviour
{
    private UnitStateMachine stateMachine;
    private UnitMovement movement;

    public UnitStateMachine StateMachine => stateMachine;
    public UnitMovement Movement => movement;

    private void Awake()
    {
        stateMachine = GetComponent<UnitStateMachine>();
        movement = GetComponent<UnitMovement>();
    }
}
