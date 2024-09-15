using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayManager : MonoBehaviour
{
    public static DayManager I { get; private set; }

    public int dayDuration = 120;
    public int nightDuration = 60;
    [SerializeField] List<SpawnManager> spawnPointManagers;


    int currentDay = 1;
    float timer = 0;

    float totalCycleDuration;
    int numberOfDNCycles;
    float currentCycleTimer;

    public int CurrentDay { get { return currentDay; } }
    
    //set to true to invoke NightToday at game start
    bool enemiesSpawning = true;

    public UnityEvent NightToDay;
    public UnityEvent DayToNight;

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(this);
            return;
        }

        I = this;
    }

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
                if(currentDay <= numberOfDNCycles)
                    spawnPointManagers[currentDay - 1].StartSpawning();
                DayToNight.Invoke();
            }
        }
        if(enemiesSpawning)
        {
            if (currentCycleTimer < dayDuration)
            {
                enemiesSpawning = false;
                if(currentDay <= numberOfDNCycles)
                {
                    NightToDay.Invoke();
                }
            }
        }

        if(currentDay > numberOfDNCycles)
        {
            if(GameManager.I.GetEnemyEntities().Count == 0)
            {
                GameManager.I.OnVictory();
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
