using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoad : MonoBehaviour
{
    public RoadsData materaillRoad; // Class chứa danh sách các material
    public Material material;

    private void Start()
    {
        // Đảm bảo RoadsData có materials
        if (materaillRoad != null && materaillRoad.roads != null && materaillRoad.roads.Count > 0)
        {
            // Chọn material ngẫu nhiên
            Material randomMaterial = materaillRoad.roads[Random.Range(0, materaillRoad.roads.Count)].material;

            // Áp dụng vào MeshRenderer
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = randomMaterial;
            }
            else
            {
                Debug.LogWarning("Không tìm thấy thành phần MeshRenderer trên object này.");
            }
        }
        else
        {
            Debug.LogWarning("RoadsData không có materials.");
        }
    }
}

