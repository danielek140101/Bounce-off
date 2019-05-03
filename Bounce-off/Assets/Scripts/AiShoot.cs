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
    private Collider2D target;
    private bool inSight = false;

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
     



        if (sightRight.collider && Time.time > shotCooldown)
        {
       
            shotCooldown = Time.time + fireRate;
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            if (sightRight.collider)
                Debug.Log($"I shoot RIGHT {sightRight.collider.name}");
            if (sightLeft.collider)
                Debug.Log($"I shoot LEFT {sightLeft.collider.name}");


        }

    }


}
