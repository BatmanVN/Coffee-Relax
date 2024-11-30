using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseRandomGate : MonoBehaviour
{
    protected virtual void SetRandomType(CupGroup cupGroup, Array itemTypes)
    {
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
                cupGroup.animate_group_item();
            }
            else
            {
                cupType.gameObject.SetActive(false);
            }
        }
    }

}
