using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidCup : MonoBehaviour
{
    public Item_type type;
    public GameObject machine;
    private Coroutine turnOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            //Check gatetype
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null)
            {
                if (cupGroup.item_Type == Item_type.Coffee)
                {
                    type = Item_type.LidCoffee;
                    cupGroup.item_Type = type;
                    Observer.Notify(ListAction.SetUpCupTypes);
                    cupGroup.animate_group_item();
                }
                if (cupGroup.item_Type == Item_type.Milk)
                {
                    type = Item_type.LidMilk;
                    cupGroup.item_Type = type;
                    Observer.Notify(ListAction.SetUpCupTypes);
                    cupGroup.animate_group_item();
                }
            }
        }
        if (other.CompareTag(Const.playerTag))
        {
            turnOff = StartCoroutine(TurnOff());
            Debug.Log("IGNORE");
        }
    }
    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.3f);
        machine.SetActive(false);
        StopCoroutine(turnOff);
    }
}
