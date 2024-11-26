using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<LightEnd> lights;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider light)
    {
        if (light.CompareTag(Const.playerTag))
        {
            foreach (LightEnd lig in lights)
            {
                lig.gameObject.SetActive(true);
            }
            Debug.Log(light.gameObject.name);
        }
    }
}
