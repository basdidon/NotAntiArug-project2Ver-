using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // serializeField make private variable can edit by unity inspector
    public static PlayerMovement instance;

    public Animator anim;

    // object variable
    public GameObject bulletPrefab;
    public Rigidbody2D playerRigidbody2d;
    public SpriteRenderer playerSpriteRenderer;
    public Transform aim;
    public Transform aimUp;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    // facing variable
    private bool facingRight = false;

    // move varible
    public float speed = 8f;
    public float moveHorizontal;

    //aim varible
    public float aimVertical;
    public bool isAimDown;
    public bool isAimUp;

    //jump variable
    public bool isGround = false;
    public bool isCanDoubleJump = false;
    public int jumpForce = 15;

    //fire variable
    private float fireRate = 0.2f;
    private float nextFire = 0.0f;

    //change bullet
    public int currentBulletsID = 1;
    public int i;

    //knockback variable
    [Header("knockback")]
    public float knockbackTime = 0.5f;
    public float knockbackTimeCounter;
    [SerializeField]
    private float knockbackPwr = 50f;


    void Start()
    {
        instance = this;
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheckpoint.position, 0.2f, whatIsGround);
        
        if (isGround)
        {
            anim.SetBool("isGround", true);
            isCanDoubleJump = true;
        }
        else
        {
            anim.SetBool("isGround", false);
        }
        
        
        
        //jump
        if (Input.GetButtonDown("Jump") /*&& jumpcount < maxJump && nextJump < Time.time*/)
        {
            jump();
        }

        //shoot
        if (Input.GetButtonDown("Fire1") && nextFire < Time.time)
        {
            shoot();
            anim.SetTrigger("Shoot");
        }

        //change bullets
        if (Input.GetButtonDown("Fire2"))
        {
            changeBullets();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            knockback();
        }

    }

    void FixedUpdate()
    {
        if (knockbackTimeCounter <= 0)
        {
            //horizontal move
            moveHorizontal = Input.GetAxis("Horizontal");
            playerRigidbody2d.velocity = new Vector2(moveHorizontal*speed,playerRigidbody2d.velocity.y) ;

            //facing handle
            if (moveHorizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                facingRight = false;
                anim.SetFloat("moveSpeed", 1f);
            }
            else if (moveHorizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                facingRight = true;
                anim.SetFloat("moveSpeed", 1f);
            }
            else
            {
                anim.SetFloat("moveSpeed", 0f);
            }
        }
        else
        {
            knockbackTimeCounter -= Time.deltaTime;
            if (facingRight)
            {
                playerRigidbody2d.velocity = new Vector2(-knockbackPwr, playerRigidbody2d.velocity.y);
            }
            else
            {
                playerRigidbody2d.velocity = new Vector2(knockbackPwr, playerRigidbody2d.velocity.y);
            }
        }

        //
        if (aimVertical < 0)
        {
            isAimDown = true;
        }else if (aimVertical > 0)
        {
            isAimUp = true;
        }
        else
        {
            isAimUp = false;
            isAimDown = false;
        }
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        //monitor what player hit
        //Debug.Log("onCollisionEnter2D  name : " + collision.gameObject.name + "    tag : " + collision.gameObject.tag);

        //reset jumpcount when player hit the Ground
        if (collision.gameObject.tag == "Platform") {
            jumpcount = 0;
            anim.SetBool("isGround", true);
        }
    }*/

    private void jump()
    {
        

        if (isGround)
        {
            playerRigidbody2d.velocity = new Vector2(playerRigidbody2d.velocity.x, jumpForce);
        }
        else
        {
            if (isCanDoubleJump)
            {
                playerRigidbody2d.velocity = new Vector2(playerRigidbody2d.velocity.x, jumpForce);
                isCanDoubleJump = false;
            }
        }
    }

    private void shoot()
    {
        i = currentBulletsID - 1;

        if (BulletsController.instance.bullets[i].currentBullets > 0)
        {
            BulletsController.instance.bullets[i].currentBullets--;

            if (facingRight)
            {
                if (isAimUp)
                {
                    GameObject bulletInstance = (GameObject)Instantiate(BulletsController.instance.bullets[i].bulletPrefab, aim.position, aim.rotation);
                    bulletInstance.GetComponent<BulletBehavior>().throwDirection(new Vector2(1,1));
                }
                else if(isAimDown)
                {
                    GameObject bulletInstance = (GameObject)Instantiate(BulletsController.instance.bullets[i].bulletPrefab, aim.position, aim.rotation);
                    bulletInstance.GetComponent<BulletBehavior>().throwDirection(new Vector2(1,-1));
                }
                else
                {
                    GameObject bulletInstance = (GameObject)Instantiate(BulletsController.instance.bullets[i].bulletPrefab, aim.position, aim.rotation);
                    bulletInstance.GetComponent<BulletBehavior>().throwDirection(Vector2.right);
                    Debug.Log("shoot_Right");
                }

            }
            else
            {
                if (isAimUp)
                {
                    GameObject bulletInstance = (GameObject)Instantiate(BulletsController.instance.bullets[i].bulletPrefab, aim.position, aim.rotation);
                    bulletInstance.GetComponent<BulletBehavior>().throwDirection(new Vector2(-1, 1));
                }
                else if (isAimDown)
                {
                    GameObject bulletInstance = (GameObject)Instantiate(BulletsController.instance.bullets[i].bulletPrefab, aim.position, aim.rotation);
                    bulletInstance.GetComponent<BulletBehavior>().throwDirection(new Vector2(-1, -1));
                }
                else
                {
                    GameObject bulletInstance = (GameObject)Instantiate(BulletsController.instance.bullets[i].bulletPrefab, aim.position, aim.rotation);
                    bulletInstance.GetComponent<BulletBehavior>().throwDirection(Vector2.left);
                    Debug.Log("shoot_Left");
                }
            }
            nextFire = Time.time + fireRate;
        }
    }

    private void changeBullets()
    {
        currentBulletsID++;
        
        if (currentBulletsID > BulletsController.instance.bullets.Count)
        {
            currentBulletsID = 1;
        }
        Debug.Log("PlayerMovement change bullets to :" + currentBulletsID + " / " + BulletsController.instance.bullets.Count);
    }

    public void knockback()
    {
        knockbackTimeCounter = knockbackTime;
        playerRigidbody2d.velocity = new Vector2(0f, knockbackPwr);
    }
}

