using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : UnitState
{
    public override void EnterState()
    {
        
    }
    public override void UpdateState()
    {
        movement.Move();
    }

    public override void ExitState()
    {
        
    }

}
