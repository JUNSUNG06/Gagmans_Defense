using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : UnitState
{
    private int attackCool;
    private bool canAttack = true;

    public override void InitState(UnitController _controller)
    {
        base.InitState(_controller);
        attackCool = controller.Stat.GetStatus(StatusType.AttackCool);
    }

    public override void EnterState()
    {
        controller.Anim.AnimationStartEvent += SetIsAttackTrue;
        controller.Anim.AnimationEndEvent += SetIsAttackFalse;
        controller.Anim.AnimationEndEvent += StartCool;
        controller.Anim.OnAnimationEvent += controller.Attack.DoAttack;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (controller.Attack.IsAttack || !canAttack)
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
        controller.Anim.AnimationEndEvent -= StartCool;
        controller.Anim.OnAnimationEvent -= controller.Attack.DoAttack;
    }

    private void SetIsAttackTrue()
    {
        controller.Attack.IsAttack = true;
    }
    
    private void SetIsAttackFalse() => controller.Attack.IsAttack = false;

    private void StartCool()
    {
        StartCoroutine(AttackCool());
    }

    private IEnumerator AttackCool()
    {
        canAttack = false;

        yield return new WaitForSeconds(attackCool);

        canAttack = true;
    }
}
