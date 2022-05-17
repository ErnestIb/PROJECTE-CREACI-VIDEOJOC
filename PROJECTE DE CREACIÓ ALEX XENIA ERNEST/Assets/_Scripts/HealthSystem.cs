using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    public ImprovedHealthBar healthBar;

    [SerializeField]
    private float maxHealth = 100.0f;

    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; private set; }

    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    public OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(float fraction);
    public OnHitDelegate OnHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CurrentHealth = -20;
        }
    }

    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
        Dead = false;
        healthBar.SetMaxHealth(maxHealth);
    }

    public virtual void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        OnHit?.Invoke(CurrentHealth / MaxHealth);

        if (CurrentHealth <= 0.0f && !Dead)
        {
            Die();
        }

        healthBar.SetHealth(CurrentHealth);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
    }
}
