using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public PowerupController controller;

    [SerializeField]
    private PowerUp powerup;

    private Transform transform_;

    [Header("Animation")]
    private Animator animator;

    private void Awake()
    {
        transform_ = transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivatePowerup();
            gameObject.SetActive(false);
        }
    }

    private void ActivatePowerup()
    {
        controller.ActivatePowerup(powerup);

    }

    public void SetPowerup(PowerUp powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
        animator = GetComponent<Animator>();
        if (powerup.name == "Healing")
        {
            animator.SetBool("Life", true);
        } else if (powerup.name == "Shield")
        {
            animator.SetBool("Shield", true);
        } else if (powerup.name == "SuperDash")
        {
            animator.SetBool("Superdash", true);
        } else if (powerup.name == "HighSpeed")
        {
            animator.SetBool("Speed", true);
        }
        
    }
}
