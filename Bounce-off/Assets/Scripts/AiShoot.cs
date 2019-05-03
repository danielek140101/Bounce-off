using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShoot : MonoBehaviour
{
    //Detect player
    public int maximumSightDistance = 0;
    public LayerMask MaskToHit;
  
    //Shoot
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    private float shotCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"My position {transform.position}");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D sight = Physics2D.Raycast(transform.position, Vector2.right, 100, MaskToHit);

        if (sight.collider != null && Time.time > shotCooldown)
        {
            shotCooldown = Time.time + fireRate;
            Instantiate(bulletPrefab, transform.position, transform.rotation);


            Debug.Log($"time {Time.time}");
            //Debug.Log($"I see {sight.collider.name} at {sight.distance}");
            Debug.DrawRay(transform.position, Vector2.right, Color.green);

        }
    }
}
