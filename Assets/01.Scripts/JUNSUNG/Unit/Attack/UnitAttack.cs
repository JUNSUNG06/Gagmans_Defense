using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : UnitComponent
{
    [field: SerializeField]
    public bool IsAttack { get; set; }
    public UnitAttackType attack;

    private List<UnitAttackType> attackTypes = new List<UnitAttackType>();

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);

        Transform attackContainer = transform.Find("AttackContainer");

        foreach (Transform child in attackContainer)
        {
            if (child.TryGetComponent<UnitAttackType>(out UnitAttackType attack))
            {
                attack.Init(GetComponent<UnitController>());
                attackTypes.Add(attack);
            }
        }
    }

    public void DoAttack()
    {
        if (attack == null)
            return;
        
        attack.Attack();
    }

    public bool SelectAttack()
    {
        if (IsAttack)
            return false;

        for (int i = 0; i < attackTypes.Count; i++)
        {
            if (attackTypes[i].CheckAttackable())
            {
                attack = attackTypes[i];
                return true;
            }
        }

        attack = null;
        return false;
    }
}
