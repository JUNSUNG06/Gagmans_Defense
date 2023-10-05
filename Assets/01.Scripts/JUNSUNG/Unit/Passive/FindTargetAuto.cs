using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetAuto : UnitPassiveType
{
    public float FindRadius = 5f;
    public LayerMask TargetLayer;

    public override void Passive()
    {
        Collider[] cols = Physics.OverlapSphere(controller.transform.position, FindRadius / 2f, TargetLayer);

        if(cols.Length > 0)
        {
            
        }
    }
}
