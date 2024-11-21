using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMoveCup : MonoBehaviour
{
    public GameObject confet_Pref;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag) || other.CompareTag(Const.playerTag))
        {
            confet_Pref.SetActive(true);
            Observer.Notify(ListAction.FinishMove);
            
        }
    }
}
