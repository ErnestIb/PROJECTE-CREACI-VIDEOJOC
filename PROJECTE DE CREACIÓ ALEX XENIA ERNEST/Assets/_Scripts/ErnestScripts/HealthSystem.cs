using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    public ShieldBar shieldBar;

    public ImprovedHealthBar healthBar;

    [SerializeField]
    public int maxHealth = 100;

    [SerializeField]
    public int maxShield = 100;

    public int currentShield;

    public int currentHealth; 

    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    public OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(int fraction);
    public OnHitDelegate OnHit;

    public bool para = false;

    public void Update()
    {
        
        
    }

    protected virtual void Start()
    {
        currentShield = 0;
        currentHealth = 30;//maxHealth;
        Dead = false;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
        
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
                currentHealth -= amountHealth;
            }
            else
            {
                currentShield -= amount;
            }
    
        } else
        {
            currentHealth -= amount;

            OnHit?.Invoke(currentHealth / maxHealth);

            if (currentHealth <= 0.0f && !Dead)
            {
                FindObjectOfType<LevelManager>().Restart();
            }
        }

        healthBar.SetHealth(currentHealth);
        shieldBar.SetShield(currentShield);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
        
    }
}
