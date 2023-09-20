using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : UnitComponent
{
    public Action AnimationStartEvent;
    public Action AnimationEndEvent;

    private Animator anim;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
        anim = transform.Find("Visual/UnitRoot").GetComponent<Animator>();
    }
}
