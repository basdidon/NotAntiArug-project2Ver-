using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private Checkpoint[] checkpoints;

    public Vector3 spawnPoint;
    private float waitToRespawn = 2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();

        spawnPoint = Player.instance.transform.position;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        Player.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        Player.instance.gameObject.SetActive(true);
        Player.instance.currentHP = Player.instance.maxHP;
        Player.instance.transform.position = spawnPoint;
    }

    


    public void DeactiveCheckPoint()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }


    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
