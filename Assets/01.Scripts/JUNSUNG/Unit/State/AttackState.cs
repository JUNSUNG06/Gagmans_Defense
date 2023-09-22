using System;
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
        controller.Anim.AnimationStartEvent += SetIsAttackTrue;
        controller.Anim.AnimationEndEvent += SetIsAttackFalse;
        controller.Anim.OnAnimationEvent += controller.Attack.DoAttack;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (controller.Attack.IsAttack)
            return;

        if (controller.Attack.SelectAttack())
        {
            controller.Anim.PlayAttackAnimation();
        }
    }

    public override void ExitState()
    {
        controller.Anim.AnimationStartEvent -= SetIsAttackTrue;
        controller.Anim.AnimationEndEvent -= SetIsAttackFalse;
        controller.Anim.OnAnimationEvent -= controller.Attack.DoAttack;
    }

    private void SetIsAttackTrue()
    {
        controller.Attack.IsAttack = true;
    }
    
    private void SetIsAttackFalse() => controller.Attack.IsAttack = false;
}
