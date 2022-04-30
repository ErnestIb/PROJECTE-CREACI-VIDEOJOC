using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float horizontal;
    public float vertical;

    public Animator animator;
    Vector2 movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        movement.y = horizontal * speed * Time.deltaTime;
        movement.x = vertical * speed * Time.deltaTime;

        transform.Translate(new Vector3(movement.x, movement.y, 0));

        animator.SetFloat("Horizontal",movement.y);
        animator.SetFloat("Vertical", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }
    public void OnMove(InputValue inputValue)
    {
        var move2d = inputValue.Get<Vector2>();
        horizontal = move2d.y;
        vertical = move2d.x;


        Debug.Log("OnMove");
    }
}
