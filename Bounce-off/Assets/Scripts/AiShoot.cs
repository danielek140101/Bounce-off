using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShoot : MonoBehaviour
{
    //Detect player
    public int maximumSightDistance = 5;
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

        RaycastHit2D sightRight = Physics2D.Raycast(transform.position, Vector2.right, maximumSightDistance, MaskToHit);
        RaycastHit2D sightLeft = Physics2D.Raycast(transform.position, Vector2.left, maximumSightDistance, MaskToHit);

        if (GetComponentInParent<EnemyAI>().facingRight) 
        {
            if (sightRight.collider != null && Time.time > shotCooldown)
            {
                shotCooldown = Time.time + fireRate;
                Instantiate(bulletPrefab, transform.position, transform.rotation);


                Debug.Log($"time {Time.time}");
                Debug.Log($"I see {sightRight.collider.name} at {sightRight.distance}");
                Debug.DrawRay(transform.position, Vector2.right, Color.green);
            }
        }
        else if (!GetComponentInParent<EnemyAI>().facingRight)
        {
            if (sightLeft.collider != null && Time.time > shotCooldown)
            {
                shotCooldown = Time.time + fireRate;
                Instantiate(bulletPrefab, transform.position, transform.rotation);


                Debug.Log($"time {Time.time}");
                Debug.Log($"I see {sightLeft.collider.name} at {sightLeft.distance}");
                Debug.DrawRay(transform.position, Vector2.right, Color.green);
            }
        }

  
    }
}
