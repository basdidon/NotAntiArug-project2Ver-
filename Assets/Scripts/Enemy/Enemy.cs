using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Enemies
    {
        none,
        Alcohol,
        Glue,
        Opium,
        Amphetamine,
        Cocaine,
        Ecstasy,
        Mitragynine,
        MagicMushroom
    }

    public enum EnemiesEffectType
    {
        depressants,
        hallucinogens,
        stimulants,
        multipleEffect
    }

    public static Enemy instance;

    [SerializeField] private int EnemyHP = 3;
    [SerializeField] private int damage = 20;
    [SerializeField] private int scoreReward = 100;

    public Enemies enemies;
    public EnemiesEffectType enemiesEffectType;

    public GameObject itemDrop;

    private void Awake()
    {
        instance = this;
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            Player.instance.dealDamage(damage);
        }
    }

    public void damageEnemy(int dmg)
    {
        EnemyHP -= dmg;

        if (EnemyHP <= 0)
        {
            Destroy(gameObject);

            FindObjectOfType<scoreManager>().addScore(scoreReward);

            int rand = Random.Range(1, 100);

            if (rand <= 50)
            {
                Instantiate(itemDrop, transform.position, itemDrop.transform.rotation);
            }
        }
    }
}
