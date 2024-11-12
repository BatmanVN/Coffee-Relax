using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupObject : MonoBehaviour
{
    //public GameObject lipstick , mascara;
    public Item_type itemType;

    // Start is called before the first frame update
    public void Start()
    {
        //mascara = transform.GetChild(1).gameObject;
        //lipstick = transform.GetChild(2).gameObject;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Const.playerTag) || collision.collider.CompareTag(Const.cupTag))
        {
            UiManager.instance._vibrate();
            Destroy(gameObject);
            Controller_Items.instance.Increase_item();

            //print("add brush");
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(Const.playerTag))
    //    {
    //        UiManager.instance._vibrate();
    //        Destroy(gameObject);
    //        Controller_Items.instance.Increase_item();
            
    //        print("add brush");
    //    }
    //}

    //public void show_mascara()
    //{
    //    mascara.SetActive(true);
    //}

    //public void show_lipstick()
    //{
    //    lipstick.SetActive(true);
    //}
}
