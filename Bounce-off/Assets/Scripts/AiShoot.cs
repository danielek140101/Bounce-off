using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShoot : MonoBehaviour
{
    //Detect player
    //public int maximumSightDistance = 0;
    //public string HitByTag = "Player";
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
        RaycastHit2D sightRight = Physics2D.Raycast(transform.position, Vector2.right);
        RaycastHit2D sightLeft = Physics2D.Raycast(transform.position, Vector2.left);

        float myPos = GetComponentInParent<Rigidbody2D>().transform.position.x;

        Shoot(sightRight, (float playerPos) => myPos < playerPos);
        Shoot(sightLeft, (float playerPos) => myPos > playerPos);


    }

    private void Shoot(RaycastHit2D sight, Func<float, bool> playerInFront)
    {
        if (sight.collider != null)
        {

            Collider2D target = sight.collider;
            bool validTarget = (target.gameObject.layer == MaskToHit);
            bool validPos = playerInFront(target.transform.position.x);


            if (validTarget && validPos && Time.time > shotCooldown)
            {
                shotCooldown = Time.time + fireRate;
                Instantiate(bulletPrefab, transform.position, transform.rotation);

                Debug.Log($"{playerInFront(target.transform.position.x)}");

                //if (sight.collider)
                //    Debug.Log($"I shoot {sight.collider.name}");

            }
        }
    }
}

