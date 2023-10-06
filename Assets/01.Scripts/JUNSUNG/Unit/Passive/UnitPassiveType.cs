using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitPassiveType : MonoBehaviour
{
    protected UnitController controller;
    protected List<UnitDecision> decisions = new List<UnitDecision>();

    public virtual void Init(UnitController _controller)
    {
        controller = _controller;
        GetComponents<UnitDecision>(decisions);
        for (int i = 0; i < decisions.Count; i++)
            decisions[i].Init(controller);
    }

    public abstract void Passive();

    public bool CanActivePassive()
    {
        for(int i = 0; i < decisions.Count; ++i) 
        {
            if(!decisions[i].Decision())
                return false;
        }

        return true;
    }
}
