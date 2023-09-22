using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : UnitAttackType
{
    public override void Attack()
    {
        base.Attack();
        
        if(controller.Target.TryGetComponent<IDamageable>(out IDamageable t))
        {
            t.GetDamaged(damage, out bool isKill);

            if(isKill)
            {
                controller.Target = null;
                controller.Movement.Stop();
            }
        }
    }
}