﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private int bulletid;

    [SerializeField]
    private float bulletSpeed = 10f;

    [SerializeField]
    private Rigidbody2D bulletRigidbody;

    [SerializeField]
    private int bulletDamage = 2;
    
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    public void throwDirection(Vector2 direction)
    {
        bulletRigidbody.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if (bulletid == 0||bulletid == collision.GetComponent<EnemyHealthManager>().typeid)
            {
                Destroy(gameObject, 0.0125f);
                collision.GetComponent<EnemyHealthManager>().damageEnemy(bulletDamage);
            }
            
        }
        
        if(collision.tag == "Platform")
        {
            Destroy(gameObject, 0.0125f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 0.0125f);
    }
}
