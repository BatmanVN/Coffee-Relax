using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FinishMoveCup : MonoBehaviour
{
    public GameObject confet_Pref;
    [SerializeField] private GameObject bonus;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag) || other.CompareTag(Const.playerTag))
        {
            confet_Pref.SetActive(true);
            bonus.SetActive(true);
            Observer.Notify(ListAction.FinishMove);
            
        }
    }
}
