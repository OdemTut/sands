using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
public class SetQualityShader : EditorWindow
{
    [MenuItem("Tools/ShaderQuality/SetMaximum")]
    public static void SetMaxSQ()
    {
        Shader.globalMaximumLOD = 700;
        Shader.DisableKeyword("MATERIAL_QUALITY_LOW");
        Shader.DisableKeyword("MATERIAL_QUALITY_MEDIUM");
        Shader.EnableKeyword("MATERIAL_QUALITY_HIGH");
    }
    [MenuItem("Tools/ShaderQuality/SetMedium")]
    public static void SetMediumSQ()
    {
        Shader.globalMaximumLOD = 400;
        Shader.DisableKeyword("MATERIAL_QUALITY_LOW");
        Shader.EnableKeyword("MATERIAL_QUALITY_MEDIUM");
        Shader.DisableKeyword("MATERIAL_QUALITY_HIGH");
    }
    [MenuItem("Tools/ShaderQuality/SetMinimum")]
    public static void SetMinSQ()
    {
        Shader.globalMaximumLOD = 200;
        Shader.EnableKeyword("MATERIAL_QUALITY_LOW");
        Shader.DisableKeyword("MATERIAL_QUALITY_MEDIUM");
        Shader.DisableKeyword("MATERIAL_QUALITY_HIGH");
    }
}
#endif