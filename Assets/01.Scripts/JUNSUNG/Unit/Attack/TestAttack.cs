using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : UnitAttackType
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("attack");
        controller.Attack.IsAttack = false;
        if(controller.Target.TryGetComponent<IDamageable>(out IDamageable t))
        {
            t.GetDamaged(damage);
        }
    }
}
