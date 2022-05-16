using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    
    public void HighSpeedStartAction()
    {
        playerMovement.activeSpeed *= 2;
    }

    public void HighSpeedEndAction()
    {
        playerMovement.activeSpeed = playerMovement.speed;
    }

}
