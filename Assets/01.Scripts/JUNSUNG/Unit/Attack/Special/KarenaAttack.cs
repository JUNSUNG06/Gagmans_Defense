using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenaAttack : UnitAttackType
{
    [Space]
    [SerializeField]
    private float angle;
    [SerializeField]
    private float distance;

    public override void Attack()
    {
        base.Attack();

        float damage = isCritical ? this.damage * 2 : this.damage;

        Collider2D[] hits = Physics2D.OverlapCircleAll(controller.Target.position, distance);

        foreach (Collider2D hit in hits)
        {
            float angle = Vector2.Dot(-controller.transform.right, (controller.Target.position - controller.transform.position).normalized) * Mathf.Rad2Deg;
            if (hit.TryGetComponent<IDamageable>(out IDamageable t) && angle <= this.angle / 2f)
            {
                t.GetDamaged(damage, out bool isKill);

                if (isKill && t == controller.Target.GetComponent<IDamageable>())
                {
                    controller.Target = null;
                    controller.Movement.Stop();
                }
            }
        }

        isCritical = false;
    }
}
