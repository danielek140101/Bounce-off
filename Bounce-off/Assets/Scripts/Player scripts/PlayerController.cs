using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Walk
    public float speed = 10f;
    public bool facingRight = true;
    Rigidbody2D rb;

    //Jump
    public float jumpForce = 300.0f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask WhatIsGroundLayer;

    public bool grounded = false;
    private bool DoneWithAirJump = false;
    private bool DoneWithGroundJump = false;

    void Start()
    {
  
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();

    }

    private void Walk()
    {
        float move = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            rb.velocity = new Vector2(speed * move, rb.velocity.y);

        }

        if (move < 0 && facingRight)
            Flip();

        if (move > 0 && !facingRight)
            Flip();
    }

    private void Jump()
    {
        bool jump = Input.GetButtonDown("Jump");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGroundLayer);
       
        //Landning
        if (grounded)
        {
            DoneWithAirJump = false;
            DoneWithGroundJump = false;
        }
 

        // Vanligt hopp
        if (jump && grounded) 
        {
            rb.AddForce(Vector2.up * jumpForce);
            DoneWithGroundJump = true;

        }

        //Lufthopp
        if (jump && !grounded && !DoneWithAirJump)
        {
            var airJumpForce = jumpForce;

            //Lufthopp efter fall
            if (DoneWithGroundJump == false)
            {
                airJumpForce *= 10;
            }

            rb.AddForce(Vector2.up * airJumpForce);
            DoneWithAirJump = true;

        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

}
