using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGateColor : MonoBehaviour
{
    [SerializeField] private List<Material> materials;
    [SerializeField] private MeshRenderer meshRenderer;

    private Coroutine changColor;
    private void Start()
    {
        changColor = StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            int random = Random.Range(0, materials.Count);
            meshRenderer.material = materials[random];
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnDestroy()
    {
        StopCoroutine(changColor);
    }
}
