using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FindTarget : UnitPassiveType
{
    public float FindRadius = 5f;
    public LayerMask TargetLayer;

    public override void Passive()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(controller.transform.position, FindRadius / 2f, TargetLayer);
        
        if(cols.Length > 0)
        {
            Debug.Log("asdasd");    
            controller.Target = FindNearestTarget(cols);
        }
    }

    private Transform FindNearestTarget(Collider2D[] cols)
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        Transform target = null;

        for(int i = 0; i < cols.Length; i++)
        {
            Vector3 diff = cols[i].transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                target = cols[i].transform;
                distance = curDistance;
            }
        }
        Debug.Log(target);
        return target;
    }
}
