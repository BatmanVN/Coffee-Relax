using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColor : MonoBehaviour
{
    [SerializeField] private Material[] randomMaterials;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (randomMaterials.Length > 0)
        {
            Material[] materials = meshRenderer.materials;  // Giữ lại mảng material hiện tại

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = randomMaterials[Random.Range(0, randomMaterials.Length)];
            }
            meshRenderer.materials = materials;  // Gán lại mảng sau khi thay đổi
        }
    }
}
