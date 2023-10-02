using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : UnitComponent
{
    public Action AnimationStartEvent;
    public Action OnAnimationEvent;
    public Action AnimationEndEvent;

    private Animator anim;

    private readonly int isRunHash = Animator.StringToHash("is_run");
    private readonly int deathHash = Animator.StringToHash("death");
    private readonly int attackHash = Animator.StringToHash("attack");
    private readonly int skillHash = Animator.StringToHash("skill");
    private readonly int stunHash = Animator.StringToHash("stun");

    public void Init(UnitController _controller, RuntimeAnimatorController animContorller)
    {
        Init(_controller);
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = animContorller;
    }

    public void SetRunAnimation(bool active)
    {
        anim.SetBool(isRunHash, active);
    }

    public void PlayDeathAnimation()
    {
        anim.SetTrigger(deathHash);
    }

    public void PlayAttackAnimation()
    {
        anim.SetTrigger(attackHash);
    }

    public void PlaySkillAnimation()
    {
        anim.SetTrigger(skillHash);
    }

    public void PlayStunAnimation()
    {
        anim.SetTrigger(stunHash);
    }

    public void PlayStartEvent() => AnimationStartEvent?.Invoke();
    public void PlayEndEvent() => AnimationEndEvent?.Invoke();
    public void OnPlayEvent() => OnAnimationEvent?.Invoke();
}
