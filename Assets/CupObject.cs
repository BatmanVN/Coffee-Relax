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
            Destroy(gameObject);
            Controller_Items.Ins.Increase_item();
            //CupGroup cupGroup = collision.GetComponent<CupGroup>();
            //if (cupGroup != null)
            //{
            //    foreach (CupType type in cupGroup.cupTypes)
            //    {
            //        if(!type.gameObject.activeSelf)
            //            type.gameObject.SetActive(false);
            //    }
            //}
        }
    }


}
