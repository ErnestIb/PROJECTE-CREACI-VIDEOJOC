using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venedor : MonoBehaviour, ITakeDamage
{
    Animator animator;
    public float life = 500;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("damage");

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
}
