using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : UnitState
{
    public override void InitState(UnitController _controller)
    {
        base.InitState(_controller);
    }

    public override void EnterState()
    {
        controller.Anim.AnimationEndEvent += () => controller.Attack.IsAttack = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        controller.Attack.Attack();
    }

    public override void ExitState()
    {
        controller.Anim.AnimationEndEvent -= () => controller.Attack.IsAttack = false;
    }
}
