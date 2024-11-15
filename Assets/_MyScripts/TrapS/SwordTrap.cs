using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwordTrap : MonoBehaviour
{
    public GameObject effectSlash;
    private bool isDecreased;
    private void OnTriggerEnter(Collider sword)
    {
        if (sword.CompareTag(Const.cupTag) ||
            sword.CompareTag(Const.playerTag))
        {
            if (!isDecreased)
            {
                Observer.Notify(ListAction.Vibrate);
                Controller_Items.Ins.decrease_item();
                GameObject slash = Instantiate(effectSlash, sword.transform.position, sword.transform.rotation);
                Destroy(slash, 1f);
            }
        }
    }
    private void OnTriggerExit(Collider hand)
    {
        if (hand.CompareTag(Const.cupTag) || hand.CompareTag(Const.playerTag))
        {
            isDecreased = true;
        }
    }
}
