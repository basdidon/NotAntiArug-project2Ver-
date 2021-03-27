using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public ScriptableEnemy scriptableEnemy;
    
    public GameObject itemDrop;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            Player.instance.dealDamage(scriptableEnemy.enemyDamage);
        }
    }

    public void damageEnemy(int dmg)
    {
        scriptableEnemy.enemyHp -= dmg;

        if (scriptableEnemy.enemyHp <= 0)
        {
            Destroy(gameObject);

            FindObjectOfType<scoreManager>().addScore(scriptableEnemy.scoreReward);

            int rand = Random.Range(1, 100);

            if (rand <= 50)
            {
                Instantiate(itemDrop, transform.position, itemDrop.transform.rotation);
            }
        }
    }
}
