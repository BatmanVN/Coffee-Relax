using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    public SkyBoxDatas materailSky; // Class chứa danh sách các material

    private void Start()
    {
        // Đảm bảo Skyboxdata có materials
        if (materailSky != null && materailSky.skies != null && materailSky.skies.Count > 0)
        {
            // Chọn material ngẫu nhiên
            Material randomMaterial = materailSky.skies[Random.Range(0, materailSky.skies.Count)].material;

            // Áp dụng vào Skybox
            RenderSettings.skybox = randomMaterial;
        }
        else
        {
            Debug.LogWarning("Skyboxdatas không có materials.");
        }
    }
}
