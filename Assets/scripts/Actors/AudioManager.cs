using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Collections;

//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.


public partial class AudioManager : MonoBehaviour
{
    Dictionary<AudioClipSO, AudioSource> sounds = new Dictionary<AudioClipSO, AudioSource>();


    void Start()
    {

    }

    public void AddClip(AudioClipSO clip)
    {
        if(clip == null)
        {
            return;
        }
        sounds[clip] = gameObject.AddComponent<AudioSource>();
        sounds[clip].clip = clip.clip;
        sounds[clip].volume = clip.volume;
        sounds[clip].pitch = clip.pitch;
        sounds[clip].loop = clip.loop;
        sounds[clip].playOnAwake = false;
        sounds[clip].spatialBlend = 0;
        
    }

    public void Play(AudioClipSO clip)
    {
        if (clip == null || !sounds.ContainsKey(clip))
            return;
        if (sounds[clip] == null)
        {
            Debug.LogWarning("Audio source is null");
            return;
        }
        if(!sounds[clip].isPlaying)
            sounds[clip].Play();
    }




    //this addition to the code was made by me, the rest was from Brackeys tutorial
    public void Stop(AudioClipSO clip)
    {
        if (clip == null || !sounds.ContainsKey(clip))
            return;
        if (sounds[clip] == null)
        {
            Debug.LogWarning("Audio source is null");
            return;
        }
        sounds[clip].Stop();
    }
}