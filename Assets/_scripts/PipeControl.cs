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
            Observer.Notify(ListAction.ShowCoffee);
        }
    }
}
