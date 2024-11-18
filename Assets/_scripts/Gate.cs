using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : BaseMachine
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //Check gatetype
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null/* && (item_Type == Item_type.IceCream || item_Type == Item_type.ice7Color)*/)
            {
                cupGroup.item_Type = machineType;
                Observer.Notify(ListAction.SetUpCupTypes);
                cupGroup.animate_group_item();
            }
        }
    }
}
