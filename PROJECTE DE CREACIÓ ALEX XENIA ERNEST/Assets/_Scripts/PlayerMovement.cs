using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    HealthSystem healthSystem;

    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;


    // Start is called before the first frame update
    public float speed = 1f;
    public float activeSpeed;

    public float multiplicadorEnHielo;
    public float floatVelocity;

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


    public bool isInHielo;


// Combat

    void Start()
    {
        activeSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();

        healthSystem = GetComponent<HealthSystem>();
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
        if (!healthSystem.isDead)
        {


            if (isInHielo)
            {
                multiplicadorEnHielo = 2;
                floatVelocity = 0.05f;
            }
            else
            {
                multiplicadorEnHielo = 1;
                floatVelocity = 1f;
            }

            movement.y = horizontal;
            movement.x = vertical;

            Vector2 targetVelocity = direction * activeSpeed * multiplicadorEnHielo;
            Vector2 realVelocity = Vector2.Lerp(rb.velocity, targetVelocity, floatVelocity);
            rb.velocity = realVelocity;

            //rb.MovePosition((Vector2)transform.position + (realVelocity));


            animator.SetFloat("Horizontal", movement.y);
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
        else
        {
            rb.velocity = new Vector2(0, 0);
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

            AudioManager.PlaySound("Dash", audioSource2);
        }
    }

    public void WalkingSound()
    {
        AudioManager.PlaySound("PlayerWalk", audioSource1);
        //AudioManager.PlaySound("PlayerWalk", GetComponent<AudioSource>());
    }



}
