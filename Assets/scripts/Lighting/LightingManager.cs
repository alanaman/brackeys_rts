using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private LightingPresetSO Preset;
    [SerializeField] private Light SunDirectionalLight;
    [SerializeField] private Light moonDirectionalLight;
    [SerializeField] private Material skyBox;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;


    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        //RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        //RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);



        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (SunDirectionalLight != null)
        {
            //SunDirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            SunDirectionalLight.intensity = Preset.SunIntensity.Evaluate(timePercent).r * Preset.maxSunIntensity;

            SunDirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

        if (moonDirectionalLight != null)
        {
            moonDirectionalLight.intensity = Preset.moonIntensity.Evaluate(timePercent).r * Preset.maxMoonIntensity;
        }

        if(skyBox != null)
        {
            skyBox.SetColor("_SkyTint", Preset.AmbientColor.Evaluate(timePercent));
        }
    }
}