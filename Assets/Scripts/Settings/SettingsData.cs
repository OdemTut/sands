using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData : MonoBehaviour
{
    //control / управление
    public static bool Vibrate; //  отвечает за включение/отключение вибрации
    ////graphics / графика
        //main
    public static int QualityPreset; //   отвечает за выбраный пресет графики
    public static float RenderScale; //  отвечает за размер рендера
    public static int AntiAliasingType; //  отвечает за режим сглаживания
    public static int AntiAliasingQuality; //  отвечает за качество сглаживания
    public static int ShaderQuality; //  отвечает за качество шейдеров
        //shadows / тени
    public static float ShadowsDistance; //  отвечает за дальность прорисовки теней
    public static float SoftShadows; //  отвечает за мягкие тени
    public static int MainShadowsQuality; // отвечает за разрешение теней от главного источника света
    public static int ShadowCascades; // отвечает за количество каскадов теней
    public static int AdditionalShadowsQuality; // отвечает за разрешение теней от дополнительных источников света
        //additional / дополнительно
    public static int PostProcessingQuality; // отвечает за качество и эффекты post processing
    public static int AdditionalLightsMode; // отвечает за режим света per pixel/per vertex
    public static int DrawDistance; // отвечает за дальность LOD и дальность прорисовки камерой
    
}
