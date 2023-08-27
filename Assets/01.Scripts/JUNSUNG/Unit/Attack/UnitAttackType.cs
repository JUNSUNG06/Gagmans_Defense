using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttackType : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    public int CoolTime;
    [SerializeField]
    protected float currentCoolTime = 0f;
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
        currentCoolTime = 0f;
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
        while(currentCoolTime < CoolTime)
        {
            currentCoolTime += Time.deltaTime;
            yield return null;
        }

        CanAttack = true;
    }
}
