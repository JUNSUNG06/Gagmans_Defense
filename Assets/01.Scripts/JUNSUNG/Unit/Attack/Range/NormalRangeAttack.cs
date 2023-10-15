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

        Vector3 firePos = controller.transform.position - Vector3.right / 2f;
        Projectile pro = projectile.Create(damage, targetLayer, firePos, 
            (controller.Target.position - firePos).normalized);

        isCritical = false; 
    }
}
