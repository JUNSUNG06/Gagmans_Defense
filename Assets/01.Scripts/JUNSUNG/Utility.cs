using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Projectile Create(this Projectile obj, int damage, LayerMask targetLayer)
    {
        Projectile projectile = GameObject.Instantiate(obj);
        projectile.damage = damage;
        projectile.targetLayer = targetLayer;

        return projectile;
    }
}
