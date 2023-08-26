using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDistance : UnitDecision
{
    [SerializeField]
    private float distance;

    public override bool Decision()
    {
        result = Vector2.Distance(transform.position, controller.Movement.TargetPos) <= distance;

        if (reverse)
            result = !result;

        return result;
    }
}
