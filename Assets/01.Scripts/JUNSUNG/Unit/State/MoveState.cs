using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : UnitState
{
    public override void EnterState()
    {
        controller.Anim.SetRunAnimation(true);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        controller.Movement.Move();    
    }

    public override void ExitState()
    {
        controller.Anim.SetRunAnimation(false);
    }
}
