using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;    

    // Start is called before the first frame update
    public float speed = 1f;
    public float activeSpeed;

    //for the dash
    public float dashSpeed = 10f;

    public float dashCooldown = 1f;
    public float dashLength = .5f;

    public float dashCounter = -1, dashCoolCounter = -1;
    
    //for the movement
    public float horizontal;
    public float vertical;

   


    public Animator animator;
    Vector2 movement;

    public GameObject dashEffect;
    public float disappearTime = 1f;


// Combat

    void Start()
    {
        activeSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Move(movement);
    }

    

    //
    // MOVEMENT
    //

    private void Move(Vector2 direction)
    {

        //basic movement

        movement.y = horizontal;
        movement.x = vertical;

        rb.MovePosition((Vector2)transform.position + (direction * activeSpeed * Time.deltaTime));

        animator.SetFloat("Horizontal",movement.y);
        animator.SetFloat("Vertical", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                
                activeSpeed -= dashSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }


    public void OnMove(InputValue inputValue)
    {
        var move2d = inputValue.Get<Vector2>();
        horizontal = move2d.y;
        vertical = move2d.x;

    }

    public void OnDash()
    {
        Debug.Log("tried to dash!");

        if (dashCounter <= 0 && dashCoolCounter <= 0)  
        {
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            //Instantiate(tree, transform.position, Quaternion.identity);              

            Debug.Log("Dashed");
            if (activeSpeed < activeSpeed + dashSpeed)
                activeSpeed += dashSpeed;
            dashCounter = dashLength;

            AudioManager.PlaySound("Dash", GetComponent<AudioSource>());
        }
    }

    public void WalkingSound()
    {
        AudioManager.PlaySound("PlayerWalk", GetComponent<AudioSource>());
    }


   
}
