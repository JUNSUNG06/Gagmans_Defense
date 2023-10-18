using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : UnitState
{
    public override void EnterState()
    {
        Debug.Log("die");

        UnitManager.Instance.RemoveUnit(controller);
        controller.Health.Die();
    }

    public override void ExitState()
    {
        
    }
}
