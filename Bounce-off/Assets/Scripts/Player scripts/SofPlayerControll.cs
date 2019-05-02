using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 10f;
    public bool facingRight = true;
    private Vector2 playerVelocity;



    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        //rb = transform.GetComponent<Rigidbody2D>();
        playerVelocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        playerVelocity.x = move * 10;

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
