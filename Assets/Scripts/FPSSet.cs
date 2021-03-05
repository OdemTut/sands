using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSSet : MonoBehaviour
{
    [Tooltip("Set maximum fps on start game. / Устанавливает максимальный ФПС при старте игры")]
    public int MaxFPS = 60;
    void Start()
    {
        Application.targetFrameRate = MaxFPS;
    }
}
