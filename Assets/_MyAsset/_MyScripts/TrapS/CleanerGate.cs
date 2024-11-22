using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider cleanGate)
    {
        if (cleanGate.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            CupGroup cupGroup = cleanGate.GetComponent<CupGroup>();
            if(cupGroup == null) return;
            cupGroup.item_Type = Item_type.Cup;
            foreach (CupType cupType in cupGroup.cupTypes)
            {
                cupType.gameObject.SetActive(false);
            }
        }
    }
}
