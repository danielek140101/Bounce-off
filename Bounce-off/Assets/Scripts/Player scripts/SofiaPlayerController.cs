using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofiaPlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool facingRight = true;
    private Vector2 playerVelocity;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        rb = transform.GetComponent<Rigidbody2D>();
        playerVelocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if(rb.velocity.x < speed)
        {
            rb.velocity += new Vector2(speed * move, 0);

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
