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
    public bool _MovementPossible;


    public Animator animator;
    Vector2 movement;


// Combat

    void Start()
    {   
        gameObject.SetActive(false);
        activeSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(movement);
        BlastInput();
    }

    //
    // MOVEMENT
    //

    private void Move(Vector2 direction)
    {
        //basic movement

        movement.y = horizontal;
        movement.x = vertical;
        if(_MovementPossible)
        {
            rb.MovePosition((Vector2)transform.position + (direction * activeSpeed * Time.deltaTime));
        
            if (movement.x < 0)
            {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
             else
            {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Charging", _MovementPossible);

    }


    public void OnMove(InputValue inputValue)
    {
        var move2d = inputValue.Get<Vector2>();
        horizontal = move2d.y;
        vertical = move2d.x;
    }

    //
    // COMBAT
    //

    private void BlastInput()
    {
        if(Input.GetMouseButton(0))
        {
            _MovementPossible = false;
        }
        else if(Input.GetMouseButtonUp(0))
        {
        _MovementPossible = true;
        }
    }
}
