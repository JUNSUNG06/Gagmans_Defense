using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistTarget : UnitDecision
{
    public override bool Decision()
    {
        result = (controller.Target != null);
        if (reverse)
            result = !result;

        return result;
    }
}
