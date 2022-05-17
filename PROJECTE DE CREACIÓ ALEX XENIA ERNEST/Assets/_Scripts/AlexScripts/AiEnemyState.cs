using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiEnemyState : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EState
    {
        Idle, 
        Wander,
        Attack
    }

    FSM<EState> brain;
    float _currentTime;
    public float _speed;
    Vector3 _direction;
    Transform _player;

    void Start()
    {
        InitFSM();

        //else
        _currentTime = 0;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);

        brain.SetOnEnter(EState.Idle, () => _currentTime = 0);
        brain.SetOnEnter(EState.Wander, () =>
        {
            _currentTime = 0;
            _direction = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0).normalized;
        });

        brain.SetOnStay(EState.Idle, UpdateIdle);
        brain.SetOnStay(EState.Wander, UpdateWander);
        brain.SetOnStay(EState.Attack, UpdateAttack);

    }


    // Update is called once per frame
    void Update()
    {
        brain.Update();
    }

    private bool IsPlayerNear(int distance)
    {
        return (Vector2.Distance(transform.position, _player.position) < 2);
    }

    private void UpdateIdle()
    {
        //Check if transition
        if (_currentTime >= 2)
        {
            brain.ChangeState(EState.Wander);
        }
        if (IsPlayerNear(2)) 
        {
            brain.ChangeState(EState.Attack);
        }


        //Execute
        _currentTime += Time.deltaTime;
    }
    private void UpdateWander()
    {
        //Check if transition
        if (_currentTime >= 4)
        {
            brain.ChangeState(EState.Idle);
        }
        if (IsPlayerNear(2))
        {
            brain.ChangeState(EState.Attack);
        }


        //Execute
        transform.position += _direction * Time.deltaTime * _speed;
        _currentTime += Time.deltaTime;
    }
    private void UpdateAttack()
    {
        //Check transition
        if (!IsPlayerNear(5))
        {
            brain.ChangeState(EState.Idle);
        }

        //Execute
        _direction = (_player.position - transform.position).normalized;
        transform.position += _direction * Time.deltaTime * _speed;
    }

}
