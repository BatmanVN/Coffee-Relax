using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterTraps : MonoBehaviour
{
    public GameObject smoke;
    private bool isDecreased;
    private void OnTriggerEnter(Collider cutter)
    {
        if (cutter.CompareTag(Const.cupTag))
        {
            if (!isDecreased)
            {
                Observer.Notify(ListAction.Vibrate);
                Controller_Items.Ins.decrease_item();
                GameObject slash = Instantiate(smoke, cutter.transform.position, cutter.transform.rotation);
                Destroy(slash, 1f);
            }
        }
    }
    private void OnTriggerExit(Collider cutter)
    {
        if (cutter.CompareTag(Const.cupTag))
        {
            isDecreased = true;
        }
    }
}
