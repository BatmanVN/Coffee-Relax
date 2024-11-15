using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaBox : MonoBehaviour
{
    public List<CupType> cupTypes;

    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            cupTypes.Add(child.GetComponent<CupType>());
        }
    }
    
}
