using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    public ShieldBar shieldBar;

    public ImprovedHealthBar healthBar;

    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private float maxShield = 100;

    public float currentShield;

    public float MaxHealth => maxHealth;
    public float CurrentHealth; 

    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    public OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(int fraction);
    public OnHitDelegate OnHit;

    public void Update()
    {
        //TakeDamage(1);
    }

    protected virtual void Start()
    {
        currentShield = 0;
        CurrentHealth = maxHealth;
        Dead = false;
        healthBar.SetMaxHealth((int)MaxHealth);
        shieldBar.SetMaxShield((int)maxShield);
    }

    public virtual void TakeDamage(float amount)
    {
        if (currentShield > 0)
        {
            if (currentShield - amount < 0)
            {
                float amountHealth = 0;
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

            OnHit?.Invoke((int)(CurrentHealth / MaxHealth));

            if (CurrentHealth <= 0.0f && !Dead)
            {
                FindObjectOfType<LevelManager>().Restart();
            }
        }

        
        healthBar.SetHealth((int)CurrentHealth);
        shieldBar.SetShield((int)currentShield);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
        
    }
}
