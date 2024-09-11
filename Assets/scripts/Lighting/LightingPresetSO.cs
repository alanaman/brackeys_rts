using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class LightingPresetSO : ScriptableObject
{
    public Gradient SunIntensity;
    public Gradient moonIntensity;
    public Gradient AmbientColor;
    public Gradient FogColor;

    public float maxSunIntensity;
    public float maxMoonIntensity;
}