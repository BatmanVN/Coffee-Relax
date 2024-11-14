using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrap : MonoBehaviour
{
    public GameObject smoke_pref;
    private void OnTriggerEnter(Collider hand)
    {
        if (hand.CompareTag(Const.cupTag) || hand.CompareTag(Const.playerTag))
        {
            Observer.Notify(ListAction.Vibrate);

            Controller_Items.instance.decrease_item();

            GameObject smoke = Instantiate(smoke_pref, hand.transform.position, hand.transform.rotation);
            Destroy(smoke, 1f);
        }
    }
}
