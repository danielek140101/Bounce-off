﻿using System;
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
    // Update is called once per frame
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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
