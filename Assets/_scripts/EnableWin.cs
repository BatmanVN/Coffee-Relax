using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWin : MonoBehaviour
{
    [SerializeField] private GameObject bonus;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag) || other.CompareTag(Const.playerTag))
        {
            bonus.SetActive(true);
        }
    }
}
