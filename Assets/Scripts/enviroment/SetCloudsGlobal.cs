using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCloudsGlobal : MonoBehaviour
{
    [Range(0, 1)]
    public float CloudsShadowAlpha = 0.35f;
    public static SetCloudsGlobal instance;
    private void Start()
    {
        instance = this;
        SetClouds(-1);
    }
    public static void SetClouds(float alpha)
    {
        instance.CloudsShadowAlpha = alpha < 0 ? instance.CloudsShadowAlpha : alpha;
        Shader.SetGlobalFloat("_NoiseScale2", RenderSettings.skybox.GetFloat("_CloudsMaskSize") / 10);
        Shader.SetGlobalFloat("_NoiseScale1", RenderSettings.skybox.GetFloat("_CloudsSize") / 10);
        Shader.SetGlobalFloat("_NoiseSpeed2", RenderSettings.skybox.GetFloat("_CloudsChangeSpeed") * 15);
        Shader.SetGlobalFloat("_NoiseSpeed1", RenderSettings.skybox.GetFloat("_WindSpeed") * 15);
        Shader.SetGlobalFloat("_CloudsShadowAlpha", instance.CloudsShadowAlpha);
    }
}
