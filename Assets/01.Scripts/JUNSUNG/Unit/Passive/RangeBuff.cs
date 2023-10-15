using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangeBuff : UnitPassiveType
{
    public List<Buff> buffList = new List<Buff>();
    public float buffTime = 3f;
    public float range = 3f;
    public LayerMask targetLayer;

    public override void Passive()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(controller.transform.position, range, targetLayer);

        foreach (Collider2D col in cols)
        {
            if(col.TryGetComponent<UnitController>(out UnitController unit))
            {
                foreach(Buff b in buffList)
                {
                    unit.Stat.Buff(b.type, b.percent, buffTime);
                }
            }
        }
    }
}
