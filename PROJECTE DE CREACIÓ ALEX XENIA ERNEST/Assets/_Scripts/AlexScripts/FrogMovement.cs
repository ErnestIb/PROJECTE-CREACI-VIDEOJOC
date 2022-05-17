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

    //attack
    float _chargeTime;
    float _chargeTimeDefault = 1f;
    float _damage = 50f;
    float _speed = 10f;
    bool _canFire;

    public Animator animator;
    [SerializeField] ChargedBlastBehaviour _chargedBlast;
    [SerializeField] Transform _firePoint;
    Vector2 movement;

// Combat

    void Start()
    {   
        activeSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();
        _chargeTime = _chargeTimeDefault;
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
            BlastMoveCharger();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            BlastMoveRelease();
        }
    }

    private void BlastMoveCharger()
    {
        _chargeTime -= Time.deltaTime;
        Debug.Log("Charging");

        if(_chargeTime <= 0 && !_canFire)
        {
            _canFire = true;
            Debug.Log("FinishedCharging");
        }

    }

    void BlastMoveRelease()
    {
        _chargeTime = _chargeTimeDefault;
        if(_canFire)
        {
            Debug.Log("Fired!");
            float angle = Utility.AngleTowardsMouse(_firePoint.position);
            Quaternion blastRotation = Quaternion.Euler(new Vector3(0,0,angle));

            var blast = Instantiate(_chargedBlast, _firePoint.position,blastRotation);
            blast.Init(_speed,_damage);
            
        }
    }

    

}
