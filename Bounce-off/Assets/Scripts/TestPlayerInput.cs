using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerInput : MonoBehaviour
{
    float speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector2.right);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector2.left);
        //}

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(x, 0, 0);
    }
}
