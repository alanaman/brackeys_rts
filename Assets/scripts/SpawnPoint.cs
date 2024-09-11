using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnStartTimeFromNightFall = 0f;


    public int nSpawns = 10;
    public float timeInbetweenSpawn = 2f;
    public int burstSpawnSize = 2;

    public GameObject enemy;
    public LayerMask enemyLayerMask;

    float secondsSinceLastSpawn = 0;

    private float spawnRadius = 10f;
    private int nCurrentSpawn = 0;

    float timer = 0f;

    void Start()
    {
    }

    //// Update is called once per frame
    void Update()
    {
        secondsSinceLastSpawn += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer < spawnStartTimeFromNightFall)
        {
            return;
        }

        if (gameObject.activeInHierarchy)
        {
            if (nCurrentSpawn < nSpawns)
            {
                if (secondsSinceLastSpawn > timeInbetweenSpawn)
                {
                    SpawnEnemyBurst();
                }
            }

        }
    }

    private void OnDisable()
    {
        nCurrentSpawn = 0;
    }

    void SpawnEnemyBurst()
    {
        for (int i = 0; i < burstSpawnSize; i++)
        {
            Vector3 spawnPoint = GenerateRandomSpawnPoint();
            Instantiate(enemy, spawnPoint, transform.rotation);
        }
        secondsSinceLastSpawn = 0;
        nCurrentSpawn += 1;
        if(nCurrentSpawn >= nSpawns)
        {
            gameObject.SetActive(false);
        }
    }

    Vector3 GenerateRandomSpawnPoint()
    {
        float x = UnityEngine.Random.Range(0f, spawnRadius);
        float z = UnityEngine.Random.Range(0f, spawnRadius);
        Vector3 spawnPoint = transform.position + new Vector3(x, .5f, z);
        Collider[] otherEnemyColliders = Physics.OverlapSphere(spawnPoint, .6f, enemyLayerMask);
        if (otherEnemyColliders.Length == 0)
        {
            return spawnPoint;
        }
        else
        {
            return GenerateRandomSpawnPoint();
        }


    }
}



