using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine : UnitComponent
{
    private Dictionary<UnitStateType, UnitState> stateDictionary = new Dictionary<UnitStateType, UnitState>();
    private UnitStateTransition anyStateTransition;

    [SerializeField]
    private UnitState currentState;
    public UnitState CurrentState => currentState;

    public override void Init()
    {
        base.Init();
        SetState();
    }

    protected override void UnitUpdate()
    {
        currentState?.UpdateState();
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
                    Debug.Log($"{transform.name}:{stateType}������Ʈ ����");
                    continue;
                }
            }
            else
            {
                Debug.Log($"{transform.name}:{stateType}������Ʈ ����");
                continue;
            }
        }

        ChangeState(UnitStateType.Idle);
    }
}
