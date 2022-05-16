using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    [SerializeField]
    private float maxHealth = 100.0f;

    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; private set; }

    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    public OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(float fraction);
    public OnHitDelegate OnHit;

    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
        Dead = false;
    }

    public virtual void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        OnHit?.Invoke(CurrentHealth / MaxHealth);

        if (CurrentHealth <= 0.0f && !Dead)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
    }
}
