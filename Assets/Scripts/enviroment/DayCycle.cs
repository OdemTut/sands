using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DayCycle : MonoBehaviour
{
    [Range(0, 1)]
    public float TimeOfDay = 0.5f;
    public DayCycleData Preset;

    public Light Sun;
    public Light Moon;
    Material SkyBox;
    public Material distortionEffect;
    static DayCycle instance;
    public bool isActive = true;
    bool needUpdateGI = true;
    bool needUpdateItems = true;
    private void OnValidate()
    {
        instance = this;
        SkyBox = RenderSettings.skybox;
        ApplyTimeOfDay();
    }
    private void Awake()
    {
        instance = this;
        SkyBox = RenderSettings.skybox;
        StartCoroutine(updateGI());
    }
    IEnumerator updateGI()
    {
        while (needUpdateGI)
        {
            DynamicGI.UpdateEnvironment();
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }
    void Update()
    {
        
        //calculate day / вычисление дня
        
        if (TimeOfDay >= 1) TimeOfDay -= 1;
        if (isActive)
            TimeOfDay += Time.deltaTime / Preset.DayDuration;
        //rotating moon and sun / поварачиваем солнце и луну
        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);
        Moon.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f + 180f, 180, 0);
        //apply settings / применение настроек
        if(needUpdateItems)
            StartCoroutine(updateItems(0.1f));
    }
    IEnumerator updateItems(float delay)
    {
        needUpdateItems = false;
        Sun.intensity = Preset.SunIntensityCurve.Evaluate(TimeOfDay);
        yield return new WaitForSecondsRealtime(delay);
        Sun.color = Preset.SunColor.Evaluate(TimeOfDay);
        yield return new WaitForSecondsRealtime(delay);
        Moon.intensity = Preset.MoonIntensityCurve.Evaluate(TimeOfDay);
        yield return new WaitForSecondsRealtime(delay);
        Moon.color = Preset.MoonColor.Evaluate(TimeOfDay);
        yield return new WaitForSecondsRealtime(delay);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(TimeOfDay);
        yield return new WaitForSecondsRealtime(delay);
        SkyBox.SetColor("_SkyColor", Preset.SkyColor.Evaluate(TimeOfDay));
        yield return new WaitForSecondsRealtime(delay);
        SkyBox.SetColor("_GorizontColor", Preset.GorizontColor.Evaluate(TimeOfDay));
        yield return new WaitForSecondsRealtime(delay);
        SkyBox.SetColor("_Ground_color", Preset.GroundColor.Evaluate(TimeOfDay));
        yield return new WaitForSecondsRealtime(delay);
        SkyBox.SetColor("Sun_color", Preset.SunColorMat.Evaluate(TimeOfDay) * Preset.SunColorHDRIntensity);
        yield return new WaitForSecondsRealtime(delay);
        SkyBox.SetColor("Moon_color", Preset.MoonColorMat.Evaluate(TimeOfDay) * Preset.MoonColorHDRIntensity);
        yield return new WaitForSecondsRealtime(delay);
        SkyBox.SetFloat("Stars_alpha", Preset.StarsIntensityCurve.Evaluate(TimeOfDay));
        yield return new WaitForSecondsRealtime(delay);
        needUpdateItems = true;
    }
#if UNITY_EDITOR
    [MenuItem("Tools/Time of day/Apply time")]
    public static void ApplyTimeOfDay()
    {
        instance.Sun.transform.localRotation = Quaternion.Euler(instance.TimeOfDay * 360f, 180, 0);
        instance.Moon.transform.localRotation = Quaternion.Euler(instance.TimeOfDay * 360f + 180f, 180, 0);
        //apply settings / применение настроек
        instance.Sun.intensity = instance.Preset.SunIntensityCurve.Evaluate(instance.TimeOfDay);
        instance.Sun.color = instance.Preset.SunColor.Evaluate(instance.TimeOfDay);
        instance.Moon.intensity = instance.Preset.MoonIntensityCurve.Evaluate(instance.TimeOfDay);
        instance.Moon.color = instance.Preset.MoonColor.Evaluate(instance.TimeOfDay);
        RenderSettings.fogColor = instance.Preset.FogColor.Evaluate(instance.TimeOfDay);
        instance.SkyBox.SetColor("_SkyColor", instance.Preset.SkyColor.Evaluate(instance.TimeOfDay));
        instance.SkyBox.SetColor("_GorizontColor", instance.Preset.GorizontColor.Evaluate(instance.TimeOfDay));
        instance.SkyBox.SetColor("_Ground_color", instance.Preset.GroundColor.Evaluate(instance.TimeOfDay));
        instance.SkyBox.SetColor("Sun_color", instance.Preset.SunColorMat.Evaluate(instance.TimeOfDay) * instance.Preset.SunColorHDRIntensity);
        instance.SkyBox.SetColor("Moon_color", instance.Preset.MoonColorMat.Evaluate(instance.TimeOfDay) * instance.Preset.MoonColorHDRIntensity);
        instance.SkyBox.SetFloat("Stars_alpha", instance.Preset.StarsIntensityCurve.Evaluate(instance.TimeOfDay));
    }
#endif
}
