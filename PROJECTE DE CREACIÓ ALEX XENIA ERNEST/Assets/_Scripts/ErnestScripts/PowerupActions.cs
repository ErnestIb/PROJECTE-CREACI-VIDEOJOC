using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private HealthSystem healthSystem;

    [SerializeField]
    private RacoonEnemic racoonEnemic;
    [SerializeField]
    private RacoonEnemic racoonEnemic1;
    [SerializeField]
    private RacoonEnemic racoonEnemic2;

    [SerializeField]
    private GhostEnemy ghostEnemy;
    [SerializeField]
    private GhostEnemy ghostEnemy1;
    [SerializeField]
    private GhostEnemy ghostEnemy2;
    [SerializeField]
    private GhostEnemy ghostEnemy3;
    [SerializeField]
    private GhostEnemy ghostEnemy4;
    [SerializeField]
    private GhostEnemy ghostEnemy5;

    public void HighSpeedStartAction()
    {
        playerMovement.activeSpeed = 10;
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

    public void FriendlyBuffStartAction()
    {
        //racoons
        racoonEnemic.followDistance = 0;
        racoonEnemic.noFollowMore = 0;

        racoonEnemic1.followDistance = 0;
        racoonEnemic1.noFollowMore = 0;

        racoonEnemic2.followDistance = 0;
        racoonEnemic2.noFollowMore = 0;

        //ghosts
        ghostEnemy.followDistance = 0;
        ghostEnemy.noFollowMore= 0;

        ghostEnemy1.followDistance = 0;
        ghostEnemy1.noFollowMore = 0;

        ghostEnemy2.followDistance = 0;
        ghostEnemy2.noFollowMore = 0;

        ghostEnemy3.followDistance = 0;
        ghostEnemy3.noFollowMore = 0;

        ghostEnemy4.followDistance = 0;
        ghostEnemy4.noFollowMore = 0;

        ghostEnemy5.followDistance = 0;
        ghostEnemy5.noFollowMore = 0;

    }
    public void FriendlyBuffEndAction()
    {
        //racoons
        racoonEnemic.followDistance = 5;
        racoonEnemic.noFollowMore = 6;

        racoonEnemic1.followDistance = 5;
        racoonEnemic1.noFollowMore = 6;

        racoonEnemic2.followDistance = 5;
        racoonEnemic2.noFollowMore = 6;

        //ghosts
        ghostEnemy.followDistance = 6;
        ghostEnemy.noFollowMore = 8;

        ghostEnemy1.followDistance = 6;
        ghostEnemy1.noFollowMore = 8;

        ghostEnemy2.followDistance = 6;
        ghostEnemy2.noFollowMore = 8;

        ghostEnemy3.followDistance = 6;
        ghostEnemy3.noFollowMore = 8;

        ghostEnemy4.followDistance = 6;
        ghostEnemy4.noFollowMore = 8;

        ghostEnemy5.followDistance = 6;
        ghostEnemy5.noFollowMore = 8;
    }





}
