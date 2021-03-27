using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public int currentLv;
    public Transform[] enemySpawnPoint;

    public GameObject Alcohol;
    public GameObject Glue;
    public GameObject Opium;
    public GameObject Amphetamine;
    public GameObject Cocaine;
    public GameObject Ecstasy;
    public GameObject Mitragynine;
    public GameObject MagicMushroom;

    public ScriptableEnemy.EnemyName[] enemiesToSpawnLvl_01 = {
        ScriptableEnemy.EnemyName.Alcohol,    ScriptableEnemy.EnemyName.Alcohol,    ScriptableEnemy.EnemyName.Alcohol,    ScriptableEnemy.EnemyName.Alcohol,    ScriptableEnemy.EnemyName.Alcohol,    ScriptableEnemy.EnemyName.Alcohol,    ScriptableEnemy.EnemyName.Alcohol,  ScriptableEnemy.EnemyName.Alcohol,  ScriptableEnemy.EnemyName.Alcohol,  ScriptableEnemy.EnemyName.Alcohol,
        ScriptableEnemy.EnemyName.Glue,       ScriptableEnemy.EnemyName.Glue,       ScriptableEnemy.EnemyName.Glue,       ScriptableEnemy.EnemyName.Glue,       ScriptableEnemy.EnemyName.Glue,       ScriptableEnemy.EnemyName.Glue,       ScriptableEnemy.EnemyName.Glue,     ScriptableEnemy.EnemyName.Glue,     ScriptableEnemy.EnemyName.Glue,     ScriptableEnemy.EnemyName.Glue, 
        ScriptableEnemy.EnemyName.Opium,      ScriptableEnemy.EnemyName.Opium,      ScriptableEnemy.EnemyName.Opium,      ScriptableEnemy.EnemyName.Opium,      ScriptableEnemy.EnemyName.Opium,      ScriptableEnemy.EnemyName.Opium,      ScriptableEnemy.EnemyName.Opium,    ScriptableEnemy.EnemyName.Opium,    ScriptableEnemy.EnemyName.Opium,
        };

    private void Start()
    {
        RandomSpawnEnemy();
        Debug.Log("num of spawnPoint = " + enemiesToSpawnLvl_01.Length);
    }

    //random enemy and spawn it to each position
    public void RandomSpawnEnemy()
    {
        
        if (currentLv == 1){
            Debug.Log("sss "+ enemiesToSpawnLvl_01.Length+" "+ enemySpawnPoint.Length);
            //Reorder enemyList
            for (int i = 0; i < enemiesToSpawnLvl_01.Length - 1; i++)
            {
                int rnd = Random.Range(i, enemiesToSpawnLvl_01.Length-1);
                ScriptableEnemy.EnemyName tempEnemyIdToSpawn = enemiesToSpawnLvl_01[rnd];
                enemiesToSpawnLvl_01[rnd] = enemiesToSpawnLvl_01[i];
                enemiesToSpawnLvl_01[i] = tempEnemyIdToSpawn;
            }

            //replace last 3 id with 0
            enemiesToSpawnLvl_01[enemySpawnPoint.Length - 3] = 0;
            enemiesToSpawnLvl_01[enemySpawnPoint.Length - 2] = 0;
            enemiesToSpawnLvl_01[enemySpawnPoint.Length - 1] = 0;

            /*for (int i = 0; i < enemiesToSpawnLvl_01.Length; i++)
            {
                Debug.Log("enemiesToSpawnLvl_01 " + i + " : " + enemiesToSpawnLvl_01[i]);
            }*/

            //reorder enemylist again
            for (int i = 0; i < enemySpawnPoint.Length - 1; i++)
            {
                int rnd = Random.Range(i, enemiesToSpawnLvl_01.Length);
                ScriptableEnemy.EnemyName tempEnemyIdToSpawn = enemiesToSpawnLvl_01[rnd];
                enemiesToSpawnLvl_01[rnd] = enemiesToSpawnLvl_01[i];
                enemiesToSpawnLvl_01[i] = tempEnemyIdToSpawn;

                //Debug.Log("enemiesToSpawnLvl_01 " + i + " : " + enemiesToSpawnLvl_01[i]);
                switch (enemiesToSpawnLvl_01[i])
                {
                    case 0:
                        break;
                    case ScriptableEnemy.EnemyName.Alcohol:
                        Instantiate(Alcohol, enemySpawnPoint[i].position, Quaternion.identity);
                        Debug.Log("spawn : Alcohol ");
                        break;
                    case ScriptableEnemy.EnemyName.Glue:
                        Instantiate(Glue, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case ScriptableEnemy.EnemyName.Opium:
                        Instantiate(Opium, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case ScriptableEnemy.EnemyName.Amphetamine:
                        Instantiate(Amphetamine, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case ScriptableEnemy.EnemyName.Cocaine:
                        Instantiate(Cocaine, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case ScriptableEnemy.EnemyName.Ecstasy:
                        Instantiate(Ecstasy, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case ScriptableEnemy.EnemyName.Mitragynine:
                        Instantiate(Mitragynine, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case ScriptableEnemy.EnemyName.MagicMushroom:
                        Instantiate(MagicMushroom, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
