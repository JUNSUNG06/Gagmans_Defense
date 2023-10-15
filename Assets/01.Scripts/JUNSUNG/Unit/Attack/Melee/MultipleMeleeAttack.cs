using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleMeleeAttack : UnitAttackType
{
    public int attackNum;
    public float range = 3f;

    public override void Attack()
    {
        base.Attack();

        float damage = isCritical ? this.damage * 2 : this.damage;

        Collider2D[] hits = Physics2D.OverlapCircleAll(controller.Target.position, range);
        IDamageable t;
        int cnt = 0;
        foreach (Collider2D hit in hits )
        {
            if (hit.TryGetComponent<IDamageable>(out t))
            {
                cnt++;
                t.GetDamaged(damage, out bool isKill);

                if (isKill)
                {
                    controller.Target = null;
                    controller.Movement.Stop();
                }
            }

            if (cnt >= attackNum)
                break;
        }

        isCritical = false;
    }
}
