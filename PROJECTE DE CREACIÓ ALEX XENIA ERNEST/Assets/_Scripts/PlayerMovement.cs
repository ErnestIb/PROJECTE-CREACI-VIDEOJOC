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
        float y = horizontal * speed * Time.deltaTime;
        float x = vertical * speed * Time.deltaTime;

        transform.Translate(new Vector3(x,y,0));
    }
    public void OnMove(InputValue inputValue)
    {
        var move2d = inputValue.Get<Vector2>();
        horizontal = move2d.y;
        vertical = move2d.x;


        Debug.Log("OnMove");
    }
}
