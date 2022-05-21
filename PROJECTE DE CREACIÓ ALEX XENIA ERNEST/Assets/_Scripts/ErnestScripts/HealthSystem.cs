using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    Animator animator;

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
        currentHealth = maxHealth;
        Dead = false;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);

        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float amount)
    {
        animator.SetTrigger("damage");

        if (currentShield > 0)
        {
            if (currentShield - (int)amount < 0)
            {
                int amountHealth = 0;
                amountHealth = (int)amount - currentShield;
                currentShield -= (int)amount;
                currentHealth -= amountHealth;

                shieldBar.SetShield(-(int)amount);
                healthBar.SetHealth(-amountHealth);
            }
            else
            {
                currentShield -= (int)amount;

                shieldBar.SetShield(-(int)amount);
            }
    
        } else
        {
            currentHealth -= (int)amount;

            healthBar.SetHealth(-(int)amount);

            OnHit?.Invoke(currentHealth / maxHealth);

            if (currentHealth <= 0.0f && !Dead)
            {
                FindObjectOfType<LevelManager>().Restart();
            }
        }

        //healthBar.SetHealth(currentHealth);
        //shieldBar.SetShield(currentShield);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
        
    }
}
