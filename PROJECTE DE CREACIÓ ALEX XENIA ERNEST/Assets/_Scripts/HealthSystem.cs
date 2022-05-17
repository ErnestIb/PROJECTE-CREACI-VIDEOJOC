using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    

    public ImprovedHealthBar healthBar;

    [SerializeField]
    private int maxHealth = 100;

    public int MaxHealth => maxHealth;
    public int CurrentHealth; //{ get; private set; }

    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    public OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(int fraction);
    public OnHitDelegate OnHit;

    public void Update()
    {
        TakeDamage(1);
    }

    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
        Dead = false;
        healthBar.SetMaxHealth(MaxHealth);
    }

    public virtual void TakeDamage(int amount)
    {
        CurrentHealth -= amount;

        OnHit?.Invoke(CurrentHealth / MaxHealth);

        if (CurrentHealth <= 0.0f && !Dead)
        {
            FindObjectOfType<LevelManager>().Restart();
        }

        healthBar.SetHealth(CurrentHealth);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
        
    }
}
