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

    public void HealingOnlyAction()
    {
       healthSystem.CurrentHealth += 30;
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
