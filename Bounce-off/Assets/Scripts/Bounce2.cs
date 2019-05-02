using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce2 : MonoBehaviour
{
    public float BounceForce = 100f;

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
        if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            {
                var rb = coll.gameObject.GetComponent<Rigidbody2D>();
                rb.AddRelativeForce(new Vector2(-BounceForce, 10));
                //rb.AddForce(transform.forward * BounceForce);
                //rb.velocity += Vector2.left * 2;
                //rb.AddRelativeForce(new Vector2(BounceForce,10));

                Debug.Log($"{coll.gameObject.name} bouncec with force of {BounceForce}");
            }
        }
    }

}
