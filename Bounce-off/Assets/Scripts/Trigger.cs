using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float BounceForce = 1000f;
    public Collision2D collision;
    public bool bounce;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll) 
    {
        if (!bounce)
        {
            bounce = true;
            collision = coll;
        }
    }

    void FixedUpdate()
    {
        if (bounce)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector3(0f , BounceForce));
            bounce = false;
            Debug.Log($"{collision.gameObject.name} bouncec with force of {BounceForce}");
        }
    }
}
