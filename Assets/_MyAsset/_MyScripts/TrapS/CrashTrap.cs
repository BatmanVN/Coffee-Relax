using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashTrap : MonoBehaviour
{
    public GameObject smoke;
    public GameObject cupCrash;
    private void OnTriggerEnter(Collider cutter)
    {
        if (cutter.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            Controller_Items.Ins.decrease_item();
            GameObject slash = Instantiate(smoke, cutter.transform.position, cutter.transform.rotation);
            Destroy(slash, 1f);
            CupObject cupObj = Instantiate(cupCrash,cutter.transform.position, cutter.transform.rotation).gameObject.GetComponent<CupObject>();
            if (cupObj != null)
            {
                cupObj.GetComponent<Collider>().enabled = false;
                cupObj.anim.SetTrigger(Const.crashTrapAnim);
            }
            Destroy(cupObj.gameObject, 5f);
        }
    }
}
