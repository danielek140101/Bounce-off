using UnityEngine;
using System.Collections;

public class NewJumpScript : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public Transform checkGround;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;

    private bool jumping;
    private bool doubleJump;
    private bool touchingGround;

    private bool hasJumped;
    private bool hasDoubleJumped;


    Rigidbody2D rb;

    void Update()
    {
         rb = GetComponent<Rigidbody2D>();

        touchingGround = Physics2D.OverlapCircle(checkGround.position, checkRadius, groundLayer);

        if (touchingGround) // Character touches the ground so we reset our jumps to be able to jump again
        {
            jumping = false;
            doubleJump = false;
            hasJumped = false;
            hasDoubleJumped = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (touchingGround) // Character is on the ground
            {
                jumping = true;
            }
            else if (!touchingGround && !hasJumped) // Character has fallen without jumping yet
            {
                jumping = true;
            }
            else if (jumping && !doubleJump) // Character is jumping but has not double jumped yet
            {
                doubleJump = true;
            }
        }
    }

    void FixedUpdate()
    {

        if (jumping && !hasJumped) // Apply the jump force when the character is jumping but not when the character has already jumped
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            hasJumped = true;
        }
        else if (doubleJump && !hasDoubleJumped) // Apply the jump force again when the character is doubleJumping but not when the character has double jumped
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            hasDoubleJumped = true;
        }
    }
}
