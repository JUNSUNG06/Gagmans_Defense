using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void GetDamaged(float damage, out bool isKill);
}
