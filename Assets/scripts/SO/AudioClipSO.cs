using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Audio Clip ", menuName = "Scriptables/Audio Clip", order = 1)]
public class AudioClipSO : ScriptableObject
{
    public AudioClip clip;
    public float volume = 1;
    public float pitch = 1;
    public bool loop = false;


    public AudioSource source;

    public IEnumerator Fade(float startVol, float endVol, float fadeTime)
    {
        //float startVolume = 0f;
        //float endVolume = this.volume;
        //float fadeTime = 5f;

        if(!source.isPlaying)
        {
            source.Play();
        }

        float timer = 0;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, endVol, timer/fadeTime);
            yield return null;
        }
        if(endVol == 0)
        {
            source.Stop();
        }
    }
}
