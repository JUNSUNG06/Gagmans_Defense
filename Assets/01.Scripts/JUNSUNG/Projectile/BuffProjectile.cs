using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Buff
{
    public StatusType type;
    public int percent;
    public float time;
}


public class BuffProjectile : Projectile
{
    public List<Buff> buffList = new List<Buff>();

    public override void HieProcess(Transform targetTrm, IDamageable target)
    {
        target.GetDamaged(damage, out bool isKill);

        if(!isKill && targetTrm.TryGetComponent<UnitController>(out UnitController unit))
        {
            foreach(Buff buff in buffList)
            {
                unit.Stat.Buff(buff.type, buff.percent, buff.time);
            }
        }
    }
}
