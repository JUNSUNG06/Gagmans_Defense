using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    protected UnitController controller;
    protected bool isInit = false;

    public virtual void Init(UnitController _controller)
    {
        controller = _controller;
        isInit = true;
    }

    protected virtual void UnitUpdate() { }

    private void Update()
    {
        if (!isInit)
            return;

        UnitUpdate();
    }
}
