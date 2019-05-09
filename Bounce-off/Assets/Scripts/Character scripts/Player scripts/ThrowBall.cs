using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animation;

    private void Start()
    {
        animation = GetComponent<Animator>();
    }
    void Update()
    {
        animation.SetBool("Shoot", false);
        if (Input.GetButtonDown("Fire1"))
        {

            animation.SetBool("Shoot", true);
            Shoot();
        }
    }

    void Shoot()
    {
        AudioManager.manager.ShootSound.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}