using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrogMovement : MonoBehaviour
{
    public Rigidbody2D rb;    

    // Start is called before the first frame update
    public float speed = 1f;
    public float activeSpeed;
    
    //for the movement
    public float horizontal;
    public float vertical;

    public Animator animator;
    Vector2 movement;

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

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    public void OnMove(InputValue inputValue)
    {
        var move2d = inputValue.Get<Vector2>();
        horizontal = move2d.y;
        vertical = move2d.x;
    }

}
