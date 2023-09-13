using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitState : MonoBehaviour
{
    protected UnitController controller;

    protected List<UnitStateTransition> transitions = new List<UnitStateTransition>();

    public virtual void InitState(UnitController _controller)
    {
        throw new System.Exception("º´½Å ¤»¤»");
        controller = _controller;

        foreach (Transform child in transform)
        {
            if(child.TryGetComponent<UnitStateTransition>(out UnitStateTransition transition))
            {
                transition.Init(controller);
                transitions.Add(transition);
            }
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
