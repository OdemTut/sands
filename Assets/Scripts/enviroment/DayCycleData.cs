using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DayCyclePreset", menuName = "ScriptableObjects/CreateDayCyclePreset", order = 1)]
public class DayCycleData : ScriptableObject
{

    public float DayDuration = 50f;

    public AnimationCurve SunIntensityCurve;
    public Gradient SunColor;
    public Gradient SunColorMat;
    [Tooltip("Это как ползунок HDR в цвете но для градиента")]
    public float SunColorHDRIntensity;
    public AnimationCurve MoonIntensityCurve;
    public Gradient MoonColor;
    public Gradient MoonColorMat;
    [Tooltip("Это как ползунок HDR в цвете но для градиента")]
    public float MoonColorHDRIntensity;
    public AnimationCurve StarsIntensityCurve;
    public Gradient FogColor;
    public Gradient SkyColor;
    public Gradient GorizontColor;
    public Gradient GroundColor;
}
