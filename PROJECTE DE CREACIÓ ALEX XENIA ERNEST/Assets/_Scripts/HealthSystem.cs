using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    

    public ImprovedHealthBar healthBar;

    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int maxShield = 100;

    public int currentShield;

    public int MaxHealth => maxHealth;
    public int CurrentHealth; 

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
        if (currentShield > 0)
        {
            if (currentShield - amount < 0)
            {
                int amountHealth = 0;
                amountHealth = amount - currentShield;
                currentShield -= amount;
                CurrentHealth -= amountHealth;
            }
            else
            {
                currentShield -= amount;
            }
            
            
        } else
        {
            CurrentHealth -= amount;

            OnHit?.Invoke(CurrentHealth / MaxHealth);

            if (CurrentHealth <= 0.0f && !Dead)
            {
                FindObjectOfType<LevelManager>().Restart();
            }
        }
        

        healthBar.SetHealth(CurrentHealth);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
        
    }
}
