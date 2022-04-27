using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float dashSpeed = 100f;
    private float lastDashTime = 4f;

    public float horizontal;
    public float vertical;

    public float dashCooldown = 2f;

    public Animator animator;
    Vector2 movement;

    public GameObject dashEffect;

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

    }

    public void OnDash()
    {
        float sinceLastDash = Time.time - lastDashTime;

        if(sinceLastDash >= dashCooldown)
        {
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            transform.Translate(new Vector3(movement.x * dashSpeed, movement.y * dashSpeed, 0));
        }
        else
        {
            Debug.Log("On dashCooldown!");
        }
        lastDashTime = Time.time;

    }
}
