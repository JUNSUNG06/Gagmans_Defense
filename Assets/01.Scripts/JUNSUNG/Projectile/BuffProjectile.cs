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

    public override void AdditiveProcess(Collider2D collision)
    {
        if(collision.TryGetComponent<UnitController>(out UnitController target))
        {
            foreach(Buff buff in buffList)
            {
                target.Stat.Buff(buff.type, buff.percent, buff.time);
            }
        }
    }
}
