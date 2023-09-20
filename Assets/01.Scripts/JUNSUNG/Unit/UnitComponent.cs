using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    protected UnitController controller;
    protected bool isInit = false;

    public virtual void Init()
    {
        controller = GetComponent<UnitController>();
        isInit = true;
    }

    protected virtual void UnitUpdate() { }

    private void Update()
    {
        if (!isInit)
            return;

        UnitUpdate();
    }

    //UnitUpdate만들고
    //UnitUpdate를 여기 Update에서 돌리셈
    //isInit == false면 리턴하고 아니면 실행하고
}
