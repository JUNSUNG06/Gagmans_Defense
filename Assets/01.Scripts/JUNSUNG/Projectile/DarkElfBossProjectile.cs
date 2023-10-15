using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkElfBossProjectile : Projectile
{
    public float range = 5f;

    public override void HieProcess(Transform targetTrm, IDamageable target)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(targetTrm.position, range, targetLayer);

        foreach (Collider2D col in cols)
        {
            if(col.TryGetComponent<IDamageable>(out IDamageable d))
            {
                d.GetDamaged(damage, out bool isKill);
            }
        }
    }
}
