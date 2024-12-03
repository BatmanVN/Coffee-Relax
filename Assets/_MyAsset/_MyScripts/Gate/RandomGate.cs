using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomGate : BaseRandomGate
{
    private void OnTriggerEnter(Collider randomGate)
    {
        if (randomGate.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            SoundManager.PlaySound(SoundType.RandomGate);
            CupGroup cupGroup = randomGate.GetComponent<CupGroup>();
            if (cupGroup == null || cupGroup.passRandomGate) return;
            cupGroup.passRandomGate = true;
            Array itemTypes = System.Enum.GetValues(typeof(Item_type));
            SetRandomType(cupGroup, itemTypes);
        }
    }
}
