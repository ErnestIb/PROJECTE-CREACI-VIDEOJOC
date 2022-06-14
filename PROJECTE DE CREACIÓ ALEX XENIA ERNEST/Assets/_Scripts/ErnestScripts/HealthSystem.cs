using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    Animator animator;

    public bool isDead;

    public ShieldBar shieldBar;

    public ImprovedHealthBar healthBar;

    [SerializeField]
    public int maxHealth = 100;

    [SerializeField]
    public int maxShield = 100;

    public int currentShield;

    public int currentHealth;

    public GameObject blood;

    [SerializeField] AudioSource audioSource5;
    [SerializeField] AudioSource audioSource6;


    protected virtual void Start()
    {
        currentShield = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);

        animator = GetComponent<Animator>();

        isDead = false;
    }

    public virtual void TakeDamage(float amount)
    {
        if (!isDead)
        {
            animator.SetTrigger("damage");

            Instantiate(blood, transform.position, Quaternion.identity);

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

            }
            else
            {
                currentHealth -= (int)amount;

                AudioManager.PlaySound("HitDamage", audioSource5);


                healthBar.SetHealth(-(int)amount);

                if (currentHealth <= 0.0f)
                {
                    AudioManager.PlaySound("Death", audioSource6);                    

                    animator.SetTrigger("Death");

                    isDead = true;
                }
            }
        }      
    }

    public void Death()
    {
        //FindObjectOfType<LevelManager>().Restart();
        SceneManager.LoadScene(2);
    }
}
