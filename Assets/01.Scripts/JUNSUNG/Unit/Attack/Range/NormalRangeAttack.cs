using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRangeAttack : UnitAttackType
{
    public Projectile projectile;
    public LayerMask targetLayer;

    public override void Attack()
    {   
        base.Attack();

        int damage = isCritical ? this.damage * 2 : this.damage;

        Projectile pro = projectile.Create(damage, targetLayer);

        isCritical = false; 
    }
}
