using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGate : BaseMachine
{
    private Coroutine turnOff;

    void Start()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //Check gatetype
            CupGroup cupGroup = other.GetComponent<CupGroup>();
            if (cupGroup != null)
            {
                cupGroup.item_Type = machineType;
                Observer.Notify(ListAction.SetUpCupTypes);
                cupGroup.animate_group_item();
                PlaySoundGate();
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
        yield return new WaitForSeconds(time);
        machine.SetActive(false);
        StopCoroutine(turnOff);
    }
}
