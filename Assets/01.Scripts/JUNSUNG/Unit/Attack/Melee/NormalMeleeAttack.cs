using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMeleeAttack : UnitAttackType
{

    //생성 위치 설정해야함
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