using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidCup : MonoBehaviour
{
    public Item_type type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //Check gatetype
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null)
            {
                type = cupGroup.item_Type;
                Observer.Notify(ListAction.SetUpCupTypes);
                cupGroup.animate_group_item();
            }
        }
    }
}
