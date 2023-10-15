using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttackType : MonoBehaviour
{
    [HideInInspector]
    public bool isCritical = false;

    [SerializeField]
    protected int damageWeight;
    [SerializeField]
    protected float coolTimeWeight;
    [SerializeField]
    protected float criticalProbWeight;
    
    protected int damage;
    protected float coolTime; 
    protected float currentCoolTime = 0f;
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

        damage = damageWeight + controller.Stat.GetStatus(StatusType.AttackPower); 
        coolTime = coolTimeWeight + controller.Stat.GetStatus(StatusType.AttackCool);
        criticalProb = criticalProbWeight + controller.Stat.GetStatus(StatusType.CriticalProb);

        CanAttack = true;
    }

    public virtual void Attack()
    {
        CanAttack = false;
        isCritical = UnityEngine.Random.Range(0, 100) <= criticalProb;
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

        while (currentCoolTime < coolTime)
        {
            currentCoolTime += Time.deltaTime;
            yield return null;
        }

        CanAttack = true;
    }
}
