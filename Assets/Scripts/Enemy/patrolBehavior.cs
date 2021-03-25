﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolBehavior : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rigidBody2d;

    //[SerializeField] LayerMask platformlayerMask; 

    private Vector3 groundCheckerOriginLeft;
    private Vector3 groundCheckerOriginRight;
    private Vector3 groundCheckerDirection;

    private bool isFacingLeft = true;

    public float speed = 0f;

    public LayerMask whatIsGround;

    void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        groundCheckerOriginLeft = boxCollider2d.bounds.center + new Vector3(-0.8f, 0, 0);
        groundCheckerOriginRight = boxCollider2d.bounds.center + new Vector3(0.8f, 0, 0);
        groundCheckerDirection = Vector2.down * (boxCollider2d.bounds.extents.y + 0.8f);


        if (!Physics2D.Raycast(groundCheckerOriginLeft, Vector2.down, boxCollider2d.bounds.extents.y + 0.8f))
        {
            isFacingLeft = false;
            //Debug.Log("Raycast left not hit platform");
        }

        if (!Physics2D.Raycast(groundCheckerOriginRight, Vector2.down, boxCollider2d.bounds.extents.y + 0.8f))
        {
            isFacingLeft = true;
            //Debug.Log("Raycast right not hit platform");
        }
        if (!Physics2D.Raycast(groundCheckerOriginRight, Vector2.down, boxCollider2d.bounds.extents.y + 0.4f))
        {
            isFacingLeft = true;
            //Debug.Log("Raycast right not hit platform");
        }
        
        //GroundChecker
        Debug.DrawRay(groundCheckerOriginLeft, groundCheckerDirection, Color.red);
        Debug.DrawRay(groundCheckerOriginRight, groundCheckerDirection,Color.red);
        //WallChecker
    }

    private void FixedUpdate()
    {
            if (isFacingLeft)
            {
                rigidBody2d.velocity = new Vector2(-speed,rigidBody2d.velocity.y);
            }
            else
            {
                rigidBody2d.velocity = new Vector2(speed, rigidBody2d.velocity.y);
            }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }
}