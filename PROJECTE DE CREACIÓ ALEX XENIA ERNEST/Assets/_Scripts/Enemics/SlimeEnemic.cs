﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlimeEnemic : MonoBehaviour, ITakeDamage
{    
    public float life = 50;
    public float velocity = 2;
    public float damage = 10;

    enum EPatrol
    {
        Start,
        Patrol,
        Wait
    }

    FSM<EPatrol> brain;



    [SerializeField]List<Transform> waypoints;

    int nextWaypoint;

    float counterTimer;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        brain = new FSM<EPatrol>(EPatrol.Start);

        // Start
        brain.SetOnStay(EPatrol.Start, () =>
        {
            nextWaypoint = 0;
            brain.ChangeState(EPatrol.Patrol);
        });

        // Patrol
        brain.SetOnStay(EPatrol.Patrol, PatrolUpdate);
        brain.SetOnExit(EPatrol.Patrol, () => ++nextWaypoint);
        brain.SetOnEnter(EPatrol.Patrol, () =>
        {
            animator.SetBool("isPatroling", true);
        });

        // Wait
        brain.SetOnStay(EPatrol.Wait, WaitUpdate);
        brain.SetOnEnter(EPatrol.Wait, () =>
        {
            animator.SetBool("isPatroling", false);
            counterTimer = 0.0f;
        });
    }

    void PatrolUpdate()
    {
        Vector3 dir = (waypoints[nextWaypoint].position - transform.position).normalized;
        transform.position += dir * Time.deltaTime;

        if (Vector3.Distance(waypoints[nextWaypoint].position, transform.position) < 0.1f)
        {
            brain.ChangeState(EPatrol.Wait);
            return;
        }
    }

    void WaitUpdate()
    {
        counterTimer += Time.deltaTime;

        if (counterTimer > 3.0f)
        {
            if (nextWaypoint >= waypoints.Count)
            {
                waypoints.Reverse();
                brain.ChangeState(EPatrol.Start);
                return;
            }

            brain.ChangeState(EPatrol.Patrol);
            return;
        }
    }

    private void Update()
    {
        brain.Update();
    }


    //Colisions
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
            
    //    }
    //}

    //Rebre mal
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Damage");

        life -= damage;

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Fer mal
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();
        if (other.CompareTag("Player") && damageTaker != null)
        {
            damageTaker.TakeDamage(damage);
        }
    }
}
