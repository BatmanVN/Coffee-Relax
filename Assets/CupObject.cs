using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupObject : MonoBehaviour
{
    //public GameObject lipstick , mascara;
    public Item_type itemType;



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Const.playerTag) || collision.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //UiManager.instance._vibrate();
            Destroy(gameObject);
            Controller_Items.instance.Increase_item();
        }
    }


}
