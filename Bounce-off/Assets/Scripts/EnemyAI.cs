using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    bool facingRight = true;
    public float distance = 2f;
    public float rotatioSpeed = 2f;
    public Quaternion originalRotation;
    public Transform groundCheck;
    void Start()
    {
        originalRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
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

    private void Flip(RaycastHit2D ground)
    {
        if (ground.collider == false)
        {
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = false;
                Debug.Log($"Vänder vänster");
            }
            else if (!facingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
                Debug.Log($"Vänder höger");
            }
        }
    }
}
