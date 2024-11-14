using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    //public Rigidbody[] lockglass_broken;
    //public GameObject locked_glass , unlock_glass;
    //public float power_break;
    public Item_type item_Type;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //Check gatetype
            //foreach (CupType cupType in cupGroup.typeCup)
            //{
            //    if (cupType.item_Type == Item_type.Cup) return;
            //    cupType.gameObject.SetActive(cupType.item_Type == item_Type);
            //}
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null && (item_Type == Item_type.IceCream || item_Type == Item_type.ice7Color))
            {
                cupGroup.item_Type = item_Type;
                foreach (CupType type in cupGroup.cupTypes)
                {
                    if (type.item_Type == Item_type.Cup) 
                        type.gameObject.SetActive(false);
                    else
                        type.gameObject.SetActive(type.item_Type == item_Type);
                }
                cupGroup.animate_group_item();
            }

            //if (item_Type == Item_type.IceCream && cupGroup != null)
            //{
            //    cupGroup.item_Type = Item_type.IceCream;
            //    foreach (CupType type in cupGroup.cupTypes)
            //    {
            //        if (type.item_Type == Item_type.Cup) continue;
            //        type.gameObject.SetActive(type.item_Type == Item_type.IceCream);
            //        if (type.item_Type == Item_type.Cup)
            //            type.gameObject.SetActive(false);
            //    }
            //    cupGroup.animate_group_item();
            //}
            //if (item_Type == Item_type.ice7Color && cupGroup != null)
            //{
            //    cupGroup.item_Type = Item_type.ice7Color;
            //    foreach (CupType type in cupGroup.cupTypes)
            //    {
            //        if (type.item_Type == Item_type.Cup) continue;
            //        type.gameObject.SetActive(type.item_Type == Item_type.ice7Color);
            //        if (type.item_Type == Item_type.Cup)
            //            type.gameObject.SetActive(false);
            //    }
            //    cupGroup.animate_group_item();
            //}
        }
    }

    //void break_glass()
    //{
    //    // innactive glass
    //    locked_glass.SetActive(false);

    //    //active glass broken
    //    unlock_glass.SetActive(true);

    //    // break glass
    //    for (int i = 0; i < lockglass_broken.Length; i++)
    //    {
    //        lockglass_broken[i].isKinematic = false;

    //        Vector3 shoot = new Vector3(Random.Range(-2, 2), Random.Range(2, 5), Random.Range(2, 6));
    //        lockglass_broken[i].AddForce(shoot * power_break, ForceMode.Impulse);
    //    }
    //}
}
