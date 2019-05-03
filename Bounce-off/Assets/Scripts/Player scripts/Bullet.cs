using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public bool knockBack;
    public float thrust = 250f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Debug.Log($"Camera: {Camera.main}");

    }


    private void FixedUpdate() 
    {
        if (knockBack && gameObject.tag == "Enemy")
        {
            knockBack = !knockBack;
            rb.AddForce(transform.right * thrust);
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            Destroy(this.gameObject);
        }
    }


}