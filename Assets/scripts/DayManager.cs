using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int numberOfDNCycles = 3;
    public int dayDuration = 120;
    public int nightDuration = 60;

    int currentDay = 1;
    float timer = 0;




    public int CurrentDay { get { return currentDay; } }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
