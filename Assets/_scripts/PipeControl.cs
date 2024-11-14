using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeControl : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null)
            {
                if (!cupGroup.iceCream.activeSelf || !cupGroup.lidCup.activeSelf)
                {
                    cupGroup.coffee.SetActive(true);
                }    
            }
        }
    }
}
