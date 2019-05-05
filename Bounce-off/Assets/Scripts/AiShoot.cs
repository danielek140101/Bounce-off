using System;
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
    private float placement;

    // Start is called before the first frame update
    void Start()
    {
    //Debug.Log($"My position {transform.position}");
}

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D sightRight = Physics2D.Raycast(transform.position, Vector2.right, 100, MaskToHit);
        RaycastHit2D sightLeft = Physics2D.Raycast(transform.position, Vector2.left, 100, MaskToHit);

        float playerPos = sightRight.collider.transform.position.x;
        float myPos = GetComponentInParent<Rigidbody2D>().transform.position.x;

        Shoot(sightRight, () => myPos < playerPos );
        Shoot(sightLeft, () => myPos > playerPos);


    }

    private void Shoot(RaycastHit2D sight, Func<bool> exp)
    {
        if (sight.collider != null && exp() && Time.time > shotCooldown)
        {
                shotCooldown = Time.time + fireRate;
                Instantiate(bulletPrefab, transform.position, transform.rotation);

                //if (sight.collider)
                //    Debug.Log($"I shoot {sight.collider.name}");
            
        }
    }
}




