using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MoonMaskUpdate : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("_MoonMaskDir", transform.forward);
    }
}
