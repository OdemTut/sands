using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class DisableInput : MonoBehaviour
{
    public EventSystem system;
    private void Update()
    {
        if (SplashScreen.isFinished)
        {
            system.enabled = true;
            this.enabled = false;
        }
    }
}
