using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private HealthSystem healthSystem;

    public void HighSpeedStartAction()
    {
        playerMovement.activeSpeed *= 2;
    }

    public void HighSpeedEndAction()
    {
        playerMovement.activeSpeed = playerMovement.speed;
    }

    public ImprovedHealthBar healthBar;

    public void HealingOnlyAction()
    {
        if (healthSystem.currentHealth >= healthSystem.maxHealth-25)
        {
            healthSystem.currentHealth += healthSystem.maxHealth - healthSystem.currentHealth;

            healthBar.SetHealth(25); 
        }
        else
        {
            healthSystem.currentHealth += 25;

            healthBar.SetHealth(25);
        }

        
    }

    public ShieldBar shieldBar;

    public void ShieldOnlyAction()
    {

        if (healthSystem.currentShield > healthSystem.maxShield - 25)
        {
            healthSystem.currentShield += healthSystem.maxShield - healthSystem.currentShield;
        }
        else
        {
            healthSystem.currentShield += 25;
        }


        shieldBar.SetShield(25);
    }

    public void DashBuffStartAction()
    {
        playerMovement.dashCooldown = 0;
    }

    public void DashBuffEndAction()
    {
        playerMovement.dashCooldown = 1;
    }

    

    

}
