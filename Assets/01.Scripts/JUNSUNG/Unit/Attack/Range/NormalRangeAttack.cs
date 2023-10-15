using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRangeAttack : UnitAttackType
{
    public Projectile projectile;
    public LayerMask targetLayer;
    public Transform fireTrm;

    public override void Attack()
    {   
        base.Attack();

        int damage = isCritical ? this.damage * 2 : this.damage;

        Projectile pro = projectile.Create(damage, targetLayer, fireTrm.position, 
            (controller.Target.position - fireTrm.position).normalized);

        isCritical = false; 
    }
}
