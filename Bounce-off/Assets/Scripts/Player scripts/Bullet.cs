using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        //Debug.Log($"Camera: {Camera.main}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(bullet);
        }
    }
    private void FixedUpdate()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            Destroy(this.gameObject);
        }
    }
}