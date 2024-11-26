using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    public Material materailSky;

    private void Start()
    {
        RenderSettings.skybox = materailSky;
    }
}
