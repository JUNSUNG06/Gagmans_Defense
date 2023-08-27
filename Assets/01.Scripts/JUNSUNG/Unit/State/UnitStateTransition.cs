using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateTransition : MonoBehaviour
{
    public UnitStateType NextState;

    private UnitController controller; 
    private List<UnitDecision> decisions = new List<UnitDecision>();

    public void Init(UnitController _controller)
    {
        controller = _controller;
        GetComponents<UnitDecision>(decisions);
        
        foreach(UnitDecision decision in decisions)
        {
            decision.Init(controller);
        }
    }

    public bool CheckDecisions()
    {
        for(int i = 0; i < decisions.Count; i++)
        {
            if(!decisions[i].Decision())
            {
                return false;
            }
        }

        TransState();
        return true;
    }

    private void TransState()
    {
        controller.StateMachine.ChangeState(NextState);
    }
}
