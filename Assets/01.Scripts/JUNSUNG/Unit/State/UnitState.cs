using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitState : MonoBehaviour
{
    protected UnitController controller;

    protected List<UnitStateTransition> transitions = new List<UnitStateTransition>();

    public virtual void InitState(UnitController _controller)
    {
        controller = _controller;

        foreach (Transform child in transform)
        {
            UnitStateTransition transition = child.GetComponent<UnitStateTransition>();
            transition.Init(controller);
            transitions.Add(transition);
        }
    }

    public abstract void EnterState();
    public virtual void UpdateState()
    {
        for(int i = 0; i < transitions.Count; i++)
        {
            transitions[i].CheckDecisions();
        }
    }
    public abstract void ExitState();
}
