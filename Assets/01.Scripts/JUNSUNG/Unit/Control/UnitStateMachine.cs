using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine : UnitComponent
{
    private Dictionary<UnitStateType, UnitState> stateDictionary = new Dictionary<UnitStateType, UnitState>();
    private UnitAnyStateTransition anyStateTransition;

    [SerializeField]
    private UnitState currentState;
    public UnitState CurrentState => currentState;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
        SetState();
    }

    protected override void UnitUpdate()
    {
        currentState?.UpdateState();
        anyStateTransition.CheckTransitions();
    }   

    public void ChangeState(UnitStateType type)
    {
        UnitState nextState;

        if (stateDictionary.ContainsKey(type))
            nextState = stateDictionary[type];
        else
            return;

        if (nextState == currentState)
            return;

        currentState?.ExitState();
        currentState = nextState;
        currentState?.EnterState();
    }

    public UnitState GetState(UnitStateType type)
    {
        return stateDictionary[type];
    }

    private void SetState()
    {
        Transform stateContainer = transform.Find("StateContainer");
        anyStateTransition = stateContainer.Find("AnyStateTransition").GetComponent<UnitAnyStateTransition>();

        anyStateTransition.Init(controller);
        foreach (UnitStateType stateType in Enum.GetValues(typeof(UnitStateType)))
        {
            Transform stateTrm = stateContainer.Find($"{stateType}State");

            if (stateTrm != null)
            {
                if (stateTrm.TryGetComponent<UnitState>(out UnitState state))
                {
                    state.InitState(GetComponent<UnitController>());
                    stateDictionary.Add(stateType, state);
                }
                else
                {
                    Debug.Log($"{transform.name}:{stateType}스테이트 없음");
                    continue;
                }
            }
            else
            {
                Debug.Log($"{transform.name}:{stateType}스테이트 없음");
                continue;
            }
        }

        ChangeState(UnitStateType.Idle);
    }
}
