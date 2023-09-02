using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDie : UnitDecision
{
    public override bool Decision()
    {
        result = controller.Health.IsDie;

        if (reverse)
            result = !result;

        return result;
    }
}
