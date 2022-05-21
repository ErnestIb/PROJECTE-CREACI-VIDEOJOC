using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float life;
    [SerializeField] private float damage;
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

    [SerializeField] private float tiempoEntreDaño = 1;
    private float tiempoSiguienteDaño;

    [SerializeField] public float followDistance;
    [SerializeField] public float noFollowMore;
    [SerializeField] private float stopNearPlayer;
    [SerializeField] private float speedRun;
    Transform player;

    Vector3 direction;

    Animator animator;

    public float push;

    private void Start()
    {
        animator = GetComponent<Animator>();

        brain = new FSM<EPatrol>(EPatrol.Start);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        
        

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
            
        });

        // Wait
        brain.SetOnStay(EPatrol.Wait, WaitUpdate);
        brain.SetOnEnter(EPatrol.Wait, () =>
        {           
            counterTimer = 0.0f;
        });


        //Follow
        brain.SetOnStay(EPatrol.Follow, FollowUpdate);
        brain.SetOnEnter(EPatrol.Follow, () =>
        {
            
        });

        //Attack
        brain.SetOnStay(EPatrol.Attack, AttackUpdate);
        brain.SetOnEnter(EPatrol.Attack, () =>
        {
            
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

        if (counterTimer > 1.0f)
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
            this.transform.Translate(Vector3.right * push * Time.deltaTime, Space.World);
            tiempoSiguienteDaño = tiempoEntreDaño;
        }
    }

    private void Update()
    {
        brain.Update();
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("TriggerDamage");
        
        life -= damage;

        if (life <= 0)
        {
            animator.SetTrigger("Death");
            brain.ChangeState(EPatrol.Wait);
        }
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
