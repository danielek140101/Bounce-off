using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofiaPlayerController : MonoBehaviour
{
    public float speed = 10f;
    private bool facingRight = true;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        rb = transform.GetComponent<Rigidbody2D>();


}

private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            var myVector = new Vector2(speed * move, rb.velocity.y);
            rb.velocity = myVector;

        }


        if (move < 0 && facingRight)
            Flip();

        if (move > 0 && !facingRight)
            Flip();

      

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }
}
