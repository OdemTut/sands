using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MoonDirectionUpdate : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("_MoonDirection", transform.forward);
    }
}
