using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Projectile Create(this Projectile obj, int damage, LayerMask targetLayer, Vector2 pos, Vector2 moveDir)
    {
        Projectile projectile = GameObject.Instantiate(obj);
        projectile.transform.position = pos;
        projectile.movedir = moveDir;
        projectile.damage = damage;
        projectile.targetLayer = targetLayer;

        return projectile;
    }
}
