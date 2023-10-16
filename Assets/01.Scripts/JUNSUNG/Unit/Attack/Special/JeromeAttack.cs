using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeromeAttack : UnitAttackType
{
    [Space]
    [SerializeField]
    private int attackCnt = 0;
    [SerializeField]
    private int specialAttackCnt = 3;
    [SerializeField]
    private float range = 2.5f;

    public override void Attack()
    {
        base.Attack();

        attackCnt++;
        int damage = isCritical ? this.damage * 2 : this.damage;

        if (controller.Target.TryGetComponent<IDamageable>(out IDamageable t))
        {
            if(attackCnt % specialAttackCnt == 0)
            {
                int specialDamage = damage + controller.Target.GetComponent<UnitController>().Stat.GetStatus(StatusType.Defense);
                Collider2D[] cols = Physics2D.OverlapCircleAll(controller.transform.position, range,
                    1 << controller.Target.gameObject.layer);

                foreach (Collider2D col in cols)
                {
                    if(col.TryGetComponent<IDamageable>(out IDamageable d))
                    {
                        PlayEffect(col.transform.position, true);
                        d.GetDamaged(specialDamage, out bool isKill);

                        if(d == t && isKill)
                        {
                            controller.Target = null;
                            controller.Movement.Stop();
                        }
                    }
                }
            }
            else
            {
                t.GetDamaged(damage, out bool isKill);

                if (isKill)
                {
                    controller.Target = null;
                    controller.Movement.Stop();
                }
            }
        }

        isCritical = false;
    }
}
