using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttack : UnitAttackType
{
    public override void Attack()
    {
        base.Attack();

        float damage = isCritical ? this.damage * 2 : this.damage;

        if (controller.Target.TryGetComponent<IDamageable>(out IDamageable t))
        {
            if(effectName != "")
                PlayEffect(controller.Target.position, controller.Visual.rotation.eulerAngles.y == 0);

            t.GetDamaged(damage, out bool isKill);

            if (isKill)
            {
                controller.Target = null;
                controller.Movement.Stop();
            }
        }

        isCritical = false;
    }
}
