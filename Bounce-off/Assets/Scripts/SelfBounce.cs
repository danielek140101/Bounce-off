using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBounce : MonoBehaviour
{
    public float bounceForce = 100f;


    void Start()
    {

    }


    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.name.Equals("Ground"))
        {
            {
                var force = new Vector2(-bounceForce, 10);
                GetComponent<Rigidbody2D>().AddRelativeForce(force);
          
                //Debug.Log($"{gameObject.name} bounce with force of {bounceForce}");
            }
        }
    }
}
