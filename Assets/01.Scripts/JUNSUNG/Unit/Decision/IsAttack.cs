using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttack : UnitDecision
{
    public override bool Decision()
    {
        result = controller.Attack.IsAttack;

        if (reverse)
            result = !result;

        return result;
    }
}
