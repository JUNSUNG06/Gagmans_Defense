using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour, IDamageable
{
    private const float DefaultHealth = 100;
    private const float DefaultHealthRecovery = 5;
    private const float DefaultDefense = 5;

    public bool Recovery;

    private bool isDie = false;
    public bool IsDie => isDie;

    public UnityEvent OnHitEvent;
    public UnityEvent OnDieEvent;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float defense;

    private void Start()
    {
        currentHealth = maxHealth;
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
}
