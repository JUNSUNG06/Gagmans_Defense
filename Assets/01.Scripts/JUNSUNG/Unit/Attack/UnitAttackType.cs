using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttackType : MonoBehaviour
{
    private const float DefaultDamage = 10;
    private const float DefaultCoolTime = 1;
    private const float DefaultCriticalProb = 10;

    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float CoolTime;
    [SerializeField]
    protected float currentCoolTime = 0f;
    [SerializeField]
    protected float criticalProb;
    protected bool CanAttack = true;
    protected List<UnitDecision> decisions = new List<UnitDecision>();
    protected UnitController controller;

    public virtual void Init(UnitController _controller)
    {
        controller = _controller;
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<UnitDecision>(out UnitDecision decision))
            {
                decision.Init(controller);
                decisions.Add(decision);
            }
        }

        CanAttack = true;
    }

    public virtual void Attack()
    {
        CanAttack = false;
        StartCoroutine(Cool());
    }

    public virtual bool CheckAttackable()
    {
        if (!CanAttack)
            return false;

        for(int i = 0; i < decisions.Count; i++)
        {
            if (!decisions[i].Decision())
                return false;
        }
        
        return true;
    }
    
    protected IEnumerator Cool()
    {
        currentCoolTime = 0f;

        while (currentCoolTime < CoolTime)
        {
            currentCoolTime += Time.deltaTime;
            yield return null;
        }

        CanAttack = true;
    }
}
