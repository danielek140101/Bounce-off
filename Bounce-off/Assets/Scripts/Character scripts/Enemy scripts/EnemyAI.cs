using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    bool facingRight = true;
    private bool inAir;
    public Transform groundCheck;
    public float maxGroundDistance = 2f;
    //public float distance = 2f;
    //public float rotationSpeed = 2f;

    //public Quaternion originalRotation;
    //public float rotateSpeed = 0.1f;
    //bool restoreRotation = false;
    void Start()
    {
        //originalRotation = transform.rotation;
        inAir = false;

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        /* Rotation not in use
         
        var Rotation = transform.rotation.z;


        if (Rotation != 0)
        {
            Debug.Log("Jag är åt fel håll");
            RestoreRotation();
            restoreRotation = true;
        }
        */
    }

 
    private void Movement()
    {
        //EnemyMovment
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Check ground
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, maxGroundDistance);

        //Draw a line to see RayCast
        Debug.DrawRay(groundCheck.position, Vector3.down, Color.magenta);

        // Change direction
            Flip(ground);
    }

    private void Flip(RaycastHit2D ground)
    {
        if (ground.collider == false && !inAir)
        {
            if (facingRight)
            {
                transform.eulerAngles = new Vector2(0, -180);
                facingRight = false;
          
            }
            else if (!facingRight && !inAir)
            {
                transform.eulerAngles = new Vector2(0, 0);
                facingRight = true;
         
            }
        }

        CheckInAir(ground);
    }

    private void CheckInAir(RaycastHit2D ground)
    {
        if (ground.collider)
        {
            inAir = false;
        }
        else
        {
            inAir = true;
        }
    }
}
