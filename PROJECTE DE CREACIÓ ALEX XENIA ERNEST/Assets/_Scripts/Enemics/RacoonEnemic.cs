using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonEnemic : MonoBehaviour, ITakeDamage
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

    [SerializeField] private float life = 100;
    [SerializeField] private float damage = 10;

    [SerializeField] List<Transform> waypoints;

    int nextWaypoint;

    float counterTimer;

    [SerializeField] private float tiempoEntreDaño = 1;
    private float tiempoSiguienteDaño;

    [SerializeField] private float followDistance;
    [SerializeField] private float noFollowMore;
    [SerializeField] private float stopNearPlayer;
    [SerializeField] private float speedRun;
    Transform player;
    Vector3 direction;
    Rigidbody2D racoon;


    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        brain = new FSM<EPatrol>(EPatrol.Start);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        racoon = this.GetComponent<Rigidbody2D>();


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
            animator.SetBool("isAttacking", false);
            counterTimer = 0.0f;
        });


        //Follow
        brain.SetOnStay(EPatrol.Follow, FollowUpdate);
        brain.SetOnEnter(EPatrol.Follow, () =>
        {
            animator.SetBool("isPatroling", true);
        });

        //Attack
        brain.SetOnStay(EPatrol.Attack, AttackUpdate);
        brain.SetOnEnter(EPatrol.Attack, () =>
        {
            animator.SetBool("isAttacking", true);
            counterTimer = 0.0f;
            racoon.isKinematic = true;
        });
        brain.SetOnExit(EPatrol.Attack, () =>
        {
            animator.SetBool("isAttacking", false);
            racoon.isKinematic = false;
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
        if (IsPlayerNear(followDistance))
        {
            brain.ChangeState(EPatrol.Follow);
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
        if (IsPlayerNear(followDistance))
        {          
            brain.ChangeState(EPatrol.Follow);                      
        }
       
    }

    private bool IsPlayerNear(float distance)
    {
        return (Vector2.Distance(transform.position, player.position) < distance);
    }

    void FollowUpdate()
    {
        //mirar si encara esta prou a prop
        if (!IsPlayerNear(noFollowMore))
        {
            brain.ChangeState(EPatrol.Wait);
        }
        if (IsPlayerNear(stopNearPlayer))
        {
            brain.ChangeState(EPatrol.Attack);
            
        }

        //el que ha de fer
        direction = (player.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * speedRun;
    }

    void AttackUpdate()
    {
        Punch();

        if (!IsPlayerNear(stopNearPlayer))
        {
            brain.ChangeState(EPatrol.Wait);
        }
    }

    void Punch()
    {
        tiempoSiguienteDaño -= Time.deltaTime;
        var damageTaker = player.GetComponent<ITakeDamage>();

        if (tiempoSiguienteDaño <= 0 && damageTaker != null)
        {
            damageTaker.TakeDamage(damage);
            tiempoSiguienteDaño = tiempoEntreDaño;
        }         
    }



    private void Update()
    {
        brain.Update();
    }

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
}
