using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBounce : MonoBehaviour
{
    public float bounceForce = 100f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.name.Equals("Ground"))
        {
                float position =  coll.transform.position.x - rb.transform.position.x;

                if(position> 0)
            {
                var force = new Vector2(-bounceForce, 10);
                rb.AddForce(force);
               // Debug.Log("Framstuds");
            }
            else
            {
                var force = new Vector2(bounceForce, 10);
                rb.AddForce(force);
                //Debug.Log("Bakstuds");

            }



            Debug.Log($"Studsar på:{coll.gameObject.name}");
            
        }
    }
}
