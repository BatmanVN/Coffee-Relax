using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrateDoor : MonoBehaviour
{
    public bool dior, chanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("brush"))
        {
            UiManager.instance._vibrate();
            //if (dior)
            //{
            //    other.GetComponent<BrushGroup>().upgrate_to_dior();
            //} 
            //else if (chanel)
            //{
            //    other.GetComponent<BrushGroup>().upgrate_to_chanel();
            //}
        }
    }
}
