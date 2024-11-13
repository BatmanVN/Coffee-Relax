using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupObject : MonoBehaviour
{
    //public GameObject lipstick , mascara;
    public Item_type itemType;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Const.playerTag) || collision.collider.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //UiManager.instance._vibrate();
            Destroy(gameObject);
            Controller_Items.instance.Increase_item();

            //print("add brush");
        }
    }


}
