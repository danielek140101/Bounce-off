﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce2 : MonoBehaviour
{
    public float bounceForce = 100f;
    private float totalForce_X = 0f;
    private float totalForce_Y = 0f;
   

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        //if (totalForce_X < 0) //manual friction
        //{
        //    var friction = bounceForce / 10;

        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(friction, 0));
        //    totalForce_X -= bounceForce / 10;

        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1));
        //    totalForce_Y -= 1;

        //    Debug.Log($"Actual Force: {totalForce_X}");
        //    Debug.Log($"TotalForce_X: {GetComponent<Rigidbody2D>().velocity.x}");

        //}
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {


        //if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
        //{
        //    {
        //        var rb = coll.gameObject.GetComponent<Rigidbody2D>();
        //        var force = new Vector2(-BounceForce, 10);
        //        rb.AddForce(force);
        //        totalForce_X += force.x;
        //        totalForce_Y += force.y;

        //        Debug.Log($"{coll.gameObject.name} bouncec with force of {BounceForce}");
        //    }
        //}


        if (!coll.gameObject.name.Equals("Ground"))
        {
            {
                var force = new Vector2(-bounceForce, 10);
                GetComponent<Rigidbody2D>().AddForce(force);
                totalForce_X += force.x;
                totalForce_Y += force.y;

         

                Debug.Log($"{gameObject.name} bounce with force of {bounceForce}");
            }
        }

  
    }

}