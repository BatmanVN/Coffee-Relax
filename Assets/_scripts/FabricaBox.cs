using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaBox : MonoBehaviour
{
    public List<CupType> cupTypes;
    //public GameObject coffe;
    //public GameObject iceCream;
    //public GameObject lid;

    // Start is called before the first frame update
    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            cupTypes.Add(child.GetComponent<CupType>());
        }
    }
    
}
