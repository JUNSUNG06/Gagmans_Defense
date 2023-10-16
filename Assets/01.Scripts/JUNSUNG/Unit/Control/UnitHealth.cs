using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : UnitComponent, IDamageable//, IAffectedStatus
{
    public bool RecoveryOption;

    private bool isDie = false;
    public bool IsDie => isDie;

    public UnityEvent OnHitEvent;
    public UnityEvent OnDieEvent;

    private float MaxHealth => controller.Stat.GetStatus(StatusType.Health);
    private float RecoveryValue => controller.Stat.GetStatus(StatusType.RecoveryValue);
    private float RecoveryTime => controller.Stat.GetStatus(StatusType.RecoveryTime);
    private float Defense => controller.Stat.GetStatus(StatusType.Defense);
    private float currentHealth;

    private Coroutine recovery;
    private WaitForSeconds recoveryTime;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);

        currentHealth = MaxHealth;
        recoveryTime = new WaitForSeconds(RecoveryTime);
        OnHitEvent.AddListener(() => PoolManager.Instance.Pop("HitEffect", transform.position));
    }

    public void GetDamaged(float damage, out bool isKill)
    {
        float calcDamage = damage - (damage * 0.01f * Defense);
        currentHealth = Mathf.Clamp(currentHealth - calcDamage, 0, MaxHealth);
        OnHitEvent?.Invoke();
        Debug.Log(damage);

        if (currentHealth == 0)
        {
            isKill = true;
            isDie = true;
            return;
        }

        isKill = false;
    }

    public void Heal(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Min(currentHealth, MaxHealth);
    }

    private void Die()
    {
        isDie = true;
        OnDieEvent?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator Recovery()
    {
        Heal(RecoveryValue);
        yield return recoveryTime;
    }

    public void StartRecovery()
    {
        recovery = StartCoroutine(Recovery());
    }

    public void StopRecovery()
    {
        StopCoroutine(recovery);
        recovery = null;
    }

    //public void OnStatusChange(StatusType type, int value)
    //{
    //    switch(type)
    //    {
    //        case StatusType.Health:
    //            maxHealth = DefaultHealth * value;
    //            break;
    //        case StatusType.HealthRecovery:
    //            recoveryHealthValue = DefaultHealthRecovery * value;
    //            break;
    //        case StatusType.Defense:
    //            defense = DefaultDefense * value;
    //            break;
    //    }
    //}
}
