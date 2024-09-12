using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int dayDuration = 120;
    public int nightDuration = 60;
    [SerializeField] List<SpawnManager> spawnPointManagers;


    int currentDay = 1;
    float timer = 0;

    float totalCycleDuration;
    int numberOfDNCycles;
    float currentCycleTimer;

    public int CurrentDay { get { return currentDay; } }

    bool enemiesSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        numberOfDNCycles = spawnPointManagers.Count;
        totalCycleDuration = dayDuration + nightDuration;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        currentCycleTimer = timer % totalCycleDuration;
        currentDay = Mathf.FloorToInt(timer / totalCycleDuration) + 1;
        if (!enemiesSpawning)
        {
            if (currentCycleTimer > dayDuration)
            {
                enemiesSpawning = true;
                //StartCoroutine(SpawnEnemies());
                spawnPointManagers[(currentDay - 1) % numberOfDNCycles].StartSpawning();
            }
        }
        if(enemiesSpawning)
        {
            if (currentCycleTimer < dayDuration)
            {
                enemiesSpawning = false;
            }
        }

    }

    public float GetLightingValue()
    {
        if (currentCycleTimer < dayDuration) 
        {
            return currentCycleTimer / dayDuration * .5f;
        } 
        else 
        {
            return .5f + 0.5f*((currentCycleTimer - dayDuration) / nightDuration);
        }
    }
}
