using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCoffeeControl : BaseMachine
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null)
            {
                cupGroup.item_Type = machineType;
                Observer.Notify(ListAction.SetUpCupTypes);
                cupGroup.animate_group_item();
            }
        }
    }
}
