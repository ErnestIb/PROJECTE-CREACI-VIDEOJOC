using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour, ITakeDamage
{
    public float life = 100;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    //Rebre mal
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Damage");

        life -= damage;

        if (life <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

   
    public void Dead()
    {
        Destroy(this.gameObject);
    }
    public void DeathSound()
    {
        AudioManager.PlaySound("BoomRacoon", GetComponent<AudioSource>());
    }
}
