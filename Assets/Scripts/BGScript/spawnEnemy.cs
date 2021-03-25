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

    /*enemyId 
     *  0 = NA            
        1 = Alcohol         เหล้า
        2 = Glue            กาว
        3 = Opium           ฝิ่น
        4 = Amphetamine     ยาบ้า
        5 = Cocaine         โคเคน
        6 = Ecstasy         ยาอี
        7 = Mitragynine     ใบกระท่อม
        8 = MagicMushroom   เห็ดขี้ควาย
    */

    public int[] enemyIdToSpawn_Lv1 = {1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3};

    private void Start()
    {
        RandomSpawnEnemy();
    }

    //random enemy and spawn it to each position
    public void RandomSpawnEnemy()
    {
        if(currentLv == 1){
            //Reorder enemyList
            for (int i = 0; i < enemyIdToSpawn_Lv1.Length - 1; i++)
            {
                int rnd = Random.Range(i, enemyIdToSpawn_Lv1.Length);
                int tempEnemyIdToSpawn = enemyIdToSpawn_Lv1[rnd];
                enemyIdToSpawn_Lv1[rnd] = enemyIdToSpawn_Lv1[i];
                enemyIdToSpawn_Lv1[i] = tempEnemyIdToSpawn;
            }

            //replace last 3 id with 0
            enemyIdToSpawn_Lv1[enemySpawnPoint.Length - 3] = 0;
            enemyIdToSpawn_Lv1[enemySpawnPoint.Length - 2] = 0;
            enemyIdToSpawn_Lv1[enemySpawnPoint.Length - 1] = 0;

            //reorder enemylist again
            for (int i = 0; i < enemySpawnPoint.Length - 1; i++)
            {
                int rnd = Random.Range(i, enemyIdToSpawn_Lv1.Length);
                int tempEnemyIdToSpawn = enemyIdToSpawn_Lv1[rnd];
                enemyIdToSpawn_Lv1[rnd] = enemyIdToSpawn_Lv1[i];
                enemyIdToSpawn_Lv1[i] = tempEnemyIdToSpawn;

                Debug.Log("enemyIdToSpawn_Lv1 " + i + " : " + enemyIdToSpawn_Lv1[i]);
                switch (enemyIdToSpawn_Lv1[i])
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(Alcohol, enemySpawnPoint[i].position, Quaternion.identity);
                        Debug.Log("spawn : Alcohol ");
                        break;
                    case 2:
                        Instantiate(Glue, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(Opium, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(Amphetamine, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(Cocaine, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(Ecstasy, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(Mitragynine, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    case 8:
                        Instantiate(MagicMushroom, enemySpawnPoint[i].position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        


   


        }



        /*//Reorder enemySpawnPoint
        for (int i = 0; i < enemySpawnPoint.Length -1 ;i++)
        {
            int rnd = Random.Range(i, enemySpawnPoint.Length);
            Vector3 tempSpawnPoint = enemySpawnPoint[rnd];
            
            
        }*/


    }
}
