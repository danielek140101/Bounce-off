using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bounce : MonoBehaviour
{
public float knockBack = 1000f;
public Rigidbody2D rb;


private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 velocity = rb.velocity;
            rb.AddForce(-velocity * knockBack);
        }
    }
}
//    public float BounceForce = 1000;
//    public Collision2D collision;
//    public bool bounce;


//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void OnCollisionEnter2D(Collision2D coll)
//    {
//        if (!bounce)
//        {
//            bounce = true;
//            collision = coll;
//        }
//    }

//    void FixedUpdate()
//    {
//        if (bounce)
//        {
//            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
//            rb.velocity = new Vector2(0, 0);
//            rb.AddForce(new Vector2(BounceForce * -5f, BounceForce));
//            bounce = false;
//            Debug.Log($"{collision.gameObject.name} bouncec with force of {BounceForce}");
//        }
//    }
}




