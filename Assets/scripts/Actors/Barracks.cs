using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    [SerializeField] GameObject spawnPoints;

    public float timeInbetweenSpawn = 2f;
    
    Dictionary<GameObject, GameObject> point_troop = new Dictionary<GameObject, GameObject>();

    float secondsSinceLastSpawn = 0;

    [SerializeField] GameObject meleeTroop;

    private void Start()
    {
        foreach(Transform child in spawnPoints.transform)
        {
            point_troop.Add(child.gameObject, null);
        }
    }

    private void Update()
    {
        secondsSinceLastSpawn += Time.deltaTime;
        bool spawned = false;
        if (secondsSinceLastSpawn > timeInbetweenSpawn)
        {
            foreach(var pair in point_troop)
            {
                if (pair.Value == null)
                {
                    GameObject inst = Instantiate(meleeTroop, pair.Key.transform.position, Quaternion.identity);
                    point_troop[pair.Key] = inst;
                    spawned = true;
                    break;
                }
            }
            if (spawned)
            {
                secondsSinceLastSpawn = 0;
            }
        }
    }
}
