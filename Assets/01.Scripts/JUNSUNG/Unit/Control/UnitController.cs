using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Dictionary<string, UnitState> stateDictionary = new Dictionary<string, UnitState>();

    [SerializeField]
    private UnitState currentState;

    private void Awake()
    {
        Transform stateContainer = transform.Find("StateContainer");

        foreach(Transform stateTrm in stateContainer)
        {
            if(stateTrm.TryGetComponent<UnitState>(out UnitState state))
            {
                state.InitState(transform);
                stateDictionary.Add(stateTrm.name, state);
            }
        }

        ChangeState("Idle");
    }

    private void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(string stateName)
    {
        UnitState nextState = stateDictionary[stateName];

        if (nextState == currentState)
            return;

        currentState?.ExitState();
        currentState = nextState;
        currentState?.EnterState();
    }
}
