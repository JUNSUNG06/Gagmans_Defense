using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : UnitComponent, IDamageable, IAffectedStatus
{
    private const float DefaultHealth = 100;
    private const float DefaultHealthRecovery = 5;
    private const float DefaultDefense = 5;

    public bool RecoveryOption;

    private bool isDie = false;
    public bool IsDie => isDie;

    public UnityEvent OnHitEvent;
    public UnityEvent OnDieEvent;

    private float maxHealth;
    private float currentHealth;
    private float recoveryHealthValue;
    private float recoveryCool;
    private float defense;

    private Coroutine recovery;
    private WaitForSeconds recoveryTime;

    public override void Init()
    {
        base.Init();

        currentHealth = maxHealth;
        recoveryTime = new WaitForSeconds(recoveryCool);
    }

    public void GetDamaged(float damage, out bool isKill)
    {
        float calcDamage = damage - (damage * 0.01f * defense);
        currentHealth = Mathf.Clamp(currentHealth - calcDamage, 0, maxHealth);
        OnHitEvent?.Invoke();
        Debug.Log(damage);

        if (currentHealth == 0)
        {
            isKill = true;
            Die();
            return;
        }

        isKill = false;
    }

    public void Heal(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    private void Die()
    {
        isDie = true;
        OnDieEvent?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator Recovery()
    {
        Heal(recoveryHealthValue);
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

    public void OnStatusChange(StatusType type, int value)
    {
        switch(type)
        {
            case StatusType.Health:
                maxHealth = DefaultHealth * value;
                break;
            case StatusType.HealthRecovery:
                recoveryHealthValue = DefaultHealthRecovery * value;
                break;
            case StatusType.Defense:
                defense = DefaultDefense * value;
                break;
        }
    }
}
