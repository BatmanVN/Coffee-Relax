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
                if (cupGroup.item_Type != Item_type.IceCream && 
                    cupGroup.item_Type != Item_type.ice7Color && 
                    cupGroup.item_Type != Item_type.Lid)
                {
                    CupType cupType = cupGroup.cupTypes.Find(type => type.item_Type == Item_type.Cup);
                    if (cupType != null)
                        cupType.gameObject.SetActive(true);
                }
            }
        }
    }
}
