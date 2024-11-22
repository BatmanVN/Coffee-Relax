using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGate : MonoBehaviour
{

    private void OnTriggerEnter(Collider randomGate)
    {
        if (randomGate.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            CupGroup cupGroup = randomGate.GetComponent<CupGroup>();
            if (cupGroup == null) return;

            Array itemTypes = System.Enum.GetValues(typeof(Item_type));
            do
            {
                cupGroup.item_Type = (Item_type)itemTypes.GetValue(UnityEngine.Random.Range(0, itemTypes.Length));
            }
            while (cupGroup.item_Type == Item_type.LidCoffee || cupGroup.item_Type == Item_type.LidMilk);

            foreach (CupType cupType in cupGroup.cupTypes)
            {
                // So sánh loại của cupGroup với từng loại của cupType
                if (cupGroup.item_Type == cupType.item_Type)
                {
                    cupType.gameObject.SetActive(true);
                }
                else
                {
                    cupType.gameObject.SetActive(false);
                }
            }
        }
    }
}
