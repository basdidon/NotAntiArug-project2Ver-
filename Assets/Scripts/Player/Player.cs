using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private SpriteRenderer spriteRendererPlayer;
    public Animator anim;

    public int maxHP;
    public int currentHP;

    public float invincibleLength;
    public float invincibleCounter;

    public int scoreToReduce = 100;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxHP = 100;
        currentHP = maxHP;

        spriteRendererPlayer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                spriteRendererPlayer.color = new Color(spriteRendererPlayer.color.r, spriteRendererPlayer.color.g, spriteRendererPlayer.color.b, 1f);
            }
        }
    }

    public void dealDamage(int damage)
    {
        if (invincibleCounter <= 0)
        {
            currentHP = currentHP - damage;
            if (currentHP <= 0)
            {
                FindObjectOfType<scoreManager>().reduceScore(scoreToReduce);
                //death
                //Debug.Log("death");
                anim.SetTrigger("Dead");

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                spriteRendererPlayer.color = new Color(spriteRendererPlayer.color.r, spriteRendererPlayer.color.g, spriteRendererPlayer.color.b, 0.5f);
                
            }
        }
    }
    
    public void healDamage(int heal)
    {
        currentHP += heal;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

    }
}
