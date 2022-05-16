﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonEnemic : MonoBehaviour
{
    enum EPatrol
    {
        Start,
        Patrol,
        Wait,
        Follow,
        Attack
    }

    FSM<EPatrol> brain;



    [SerializeField] List<Transform> waypoints;

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

        if (counterTimer > 2.0f)
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
}
