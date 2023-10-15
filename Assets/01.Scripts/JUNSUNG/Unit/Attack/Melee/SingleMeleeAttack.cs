using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMeleeAttack : UnitAttackType
{
    public override void Attack()
    {
        base.Attack();

        float damage = isCritical ? this.damage * 2 : this.damage;

        if (controller.Target.TryGetComponent<IDamageable>(out IDamageable t))
        {
            t.GetDamaged(damage, out bool isKill);

            if(isKill)
            {
                controller.Target = null;
                controller.Movement.Stop();
            }
        }

        isCritical = false;
    }
}