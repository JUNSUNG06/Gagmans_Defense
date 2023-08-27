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
    }
}
