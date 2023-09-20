using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : UnitComponent
{
    public Action AnimationStartEvent;
    public Action AnimationEndEvent;

    private Animator anim;

    public override void Init()
    {
        base.Init();
        anim = transform.Find("Visual/UnitRoot").GetComponent<Animator>();
    }
}
