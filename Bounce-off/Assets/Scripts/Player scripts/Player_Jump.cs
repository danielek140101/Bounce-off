using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public float jumpForce = 300.0f;
    public bool DoneWithAirJump = false;
    public bool groundJump = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public bool grounded = false;
    public LayerMask WhatIsGround;


    private void FixedUpdate()
    {
        bool jump = Input.GetButtonDown("Jump");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);

        if (grounded)
            DoneWithAirJump = false;
        groundJump = false;

        if (jump && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
            groundJump = true;
           
        }

        if(jump && !grounded && !DoneWithAirJump)
        {
            var airJumpForce = jumpForce;

            if(groundJump == true)
            {
                airJumpForce *= 5;
            }
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * airJumpForce);

            DoneWithAirJump = true;

        }
    }
}
