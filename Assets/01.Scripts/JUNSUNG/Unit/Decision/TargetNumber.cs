using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNumber : UnitDecision
{
    public float range = 5;
    public int num = 3;
    public LayerMask targetLayer;

    public override bool Decision()
    {
        bool result = false;

        Collider2D[] hits = Physics2D.OverlapCircleAll(controller.transform.position, range);
        int num = 0;

        foreach (Collider2D hit in hits)
        {
            if (1 << hit.transform.gameObject.layer == targetLayer)
                num++;

            if (num >= this.num)
            {
                result = true;
                break;
            }
        }

        if (reverse)
            result = !result;

        return result;
    }
}
