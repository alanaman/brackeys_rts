using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Collections;

//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.


public partial class AudioManager : MonoBehaviour
{
    [SerializeField]
    public List<AudioClipSO> sounds;


    [SerializeField] AudioClipSO dayTheme;
    [SerializeField] AudioClipSO nightTheme;

    public static AudioManager I;
    //AudioManager

    void Awake()
    {

        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (AudioClipSO s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        DayManager.I.NightToDay.AddListener(PlayDayTheme);
        DayManager.I.DayToNight.AddListener(PlayNightTheme);

    }

    public void PlayDayTheme()
    {
        Play(dayTheme);
        Stop(nightTheme);
    }

    public void PlayNightTheme()
    {
        Play(nightTheme);
        Stop(dayTheme);
    }



    public void Play(AudioClipSO clip)
    {
        if(clip.source == null)
        {
            Debug.LogWarning("Audio source is null");
        }
        StartCoroutine(clip.Fade(0, clip.volume, 2));
    }
    

    //this addition to the code was made by me, the rest was from Brackeys tutorial
    public void Stop(AudioClipSO clip)
    {
        if(clip.source == null)
        {
            Debug.LogWarning("Audio source is null");
        }
        StartCoroutine(clip.Fade(clip.source.volume, 0, 2));
    }
}