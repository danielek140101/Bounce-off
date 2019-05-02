using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerInput : MonoBehaviour
{
    public float speed = 0f;
    public float acceleration = 0f;
    public float deacceleration = 0f;
    public float maxSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left);
        }

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 8.0f;
        //var y = Input.GetAxis("Vertical") * Time.deltaTime * 8.0f;
        //transform.Translate(x, y, 0);
    }
}
