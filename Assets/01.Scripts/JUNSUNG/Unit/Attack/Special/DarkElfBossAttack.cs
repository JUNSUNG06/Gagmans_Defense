using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkElfBossAttack : UnitAttackType
{
    public int attackNum = 0;
    public Projectile projectile;
    public Projectile specialProjectile;
    public LayerMask targetLayer;
    public Transform fireTrm;

    public override void Attack()
    {
        base.Attack();
        attackNum++;
        int damage = isCritical ? this.damage * 2 : this.damage;

        if(attackNum % 3 == 0)
        {
            Projectile pro = specialProjectile.Create(damage, targetLayer, fireTrm.position,
            (controller.Target.position - fireTrm.position).normalized);
        }
        else
        {
            Projectile pro = projectile.Create(damage, targetLayer, fireTrm.position,
            (controller.Target.position - fireTrm.position).normalized);
        }

        isCritical = false;
    }
}
