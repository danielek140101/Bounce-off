using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public bool facingRight = true;
    public float distance = 2f;
    public float rotationSpeed = 2f;
    public Transform groundCheck;
    private bool inAir;

    public Quaternion originalRotation;
    public float rotateSpeed = 0.1f;
    //bool restoreRotation = false;
    void Start()
    {
        originalRotation = transform.rotation;
        inAir = false;

    }
    // Update is called once per frame
    void Update()
    {
        var Rotation = transform.rotation.z;


        if (Rotation != 0)
        {
            //Debug.Log("Jag är åt fel håll");
            RestoreRotation();
            // restoreRotation = true;
        }

        Movement();

      //  CheckInAir();
    }

 
    private void Movement()
    {

        //RaycastHit2D myRay = Physics2D.Raycast(transform.position, Vector2.down);
        //Debug.Log($"{myRay.collider.name}");

        //EnemyMovment
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Check ground
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down);


        //Draw a line to see RayCast
        Debug.DrawRay(groundCheck.position, Vector3.down, Color.magenta);

        // Change direction
      
            Flip(ground);

        
    }

    private void RestoreRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.time * rotateSpeed);
    }

    public void Flip(RaycastHit2D ground)
    {
        if (ground.collider == false && !inAir)
        {
            if (facingRight)
            {
                transform.eulerAngles = new Vector2(0, -180);
                facingRight = false;
                Debug.Log("Jag vänder håll ground");

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
