using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrap : MonoBehaviour
{
    [SerializeField] private GameObject waterEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupMapTag))
        {
            GameObject effect = Instantiate(waterEffect,other.transform.position,other.transform.rotation);
            Destroy(effect,2f);
        }
    }
}
