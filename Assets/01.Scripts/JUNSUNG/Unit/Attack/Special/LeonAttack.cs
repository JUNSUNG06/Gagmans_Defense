using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeonAttack : UnitAttackType
{
    [Space]
    [SerializeField]
    private float buffTime = 10f;
    [SerializeField]
    private int buffCnt = 0;
    [SerializeField]
    private int buffAmount = 110;

    public override void Attack()
    {
        base.Attack();

        float damage = isCritical ? this.damage * 2 : this.damage;

        if (controller.Target.TryGetComponent<IDamageable>(out IDamageable t))
        {
            Debug.Log(controller.Visual.rotation.eulerAngles.y == 0);
            PlayEffect(controller.Target.position, controller.Visual.rotation.eulerAngles.y == 0);
            t.GetDamaged(damage, out bool isKill);

            if (isKill)
            {
                controller.Target = null;
                controller.Movement.Stop();

                if (buffCnt < 10)
                    StartCoroutine(Buff());
            }
        }

        isCritical = false;
    }

    private IEnumerator Buff()
    {
        foreach(StatusType t in Enum.GetValues(typeof(StatusType)))
        {
            controller.Stat.Buff(t, buffAmount, buffTime);
        }
        buffCnt++;

        yield return new WaitForSeconds(buffTime);

        buffCnt--;
    }
}
