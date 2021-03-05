using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData : MonoBehaviour
{
    //control / ����������
    public static bool Vibrate; //  �������� �� ���������/���������� ��������
    ////graphics / �������
        //main
    public static int QualityPreset; //   �������� �� �������� ������ �������
    public static float RenderScale; //  �������� �� ������ �������
    public static int AntiAliasingType; //  �������� �� ����� �����������
    public static int AntiAliasingQuality; //  �������� �� �������� �����������
    public static int ShaderQuality; //  �������� �� �������� ��������
        //shadows / ����
    public static float ShadowsDistance; //  �������� �� ��������� ���������� �����
    public static float SoftShadows; //  �������� �� ������ ����
    public static int MainShadowsQuality; // �������� �� ���������� ����� �� �������� ��������� �����
    public static int ShadowCascades; // �������� �� ���������� �������� �����
    public static int AdditionalShadowsQuality; // �������� �� ���������� ����� �� �������������� ���������� �����
        //additional / �������������
    public static int PostProcessingQuality; // �������� �� �������� � ������� post processing
    public static int AdditionalLightsMode; // �������� �� ����� ����� per pixel/per vertex
    public static int DrawDistance; // �������� �� ��������� LOD � ��������� ���������� �������
    
}
