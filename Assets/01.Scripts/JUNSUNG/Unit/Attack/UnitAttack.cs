using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : UnitComponent
{
    [field: SerializeField]
    public bool IsAttack { get; set; }

    private List<UnitAttackType> attacks = new List<UnitAttackType>();

    public override void Init()
    {
        base.Init();

        Transform attackContainer = transform.Find("AttackContainer");

        foreach (Transform child in attackContainer)
        {
            if (child.TryGetComponent<UnitAttackType>(out UnitAttackType attack))
            {
                attack.Init(GetComponent<UnitController>());
                attacks.Add(attack);
            }
        }
    }

    public void Attack()
    {
        if (IsAttack)
            return;

        for (int i = 0; i < attacks.Count; i++)
        {
            if (attacks[i].CheckAttackable())
            {
                IsAttack = true;
                attacks[i].Attack();
                return;
            }
        }
    }
}
