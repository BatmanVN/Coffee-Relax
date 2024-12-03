using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterTraps : MonoBehaviour
{
    public GameObject smoke;
    private bool isDecreased;
    private Coroutine setTrap;



    private void OnTriggerEnter(Collider cutter)
    {
        if (cutter.CompareTag(Const.cupTag))
        {
            if (!isDecreased)
            {
                SoundManager.PlayIntSound(SoundType.TrapsSound, 4);
                Observer.Notify(ListAction.Vibrate);
                Controller_Items.Ins.decrease_item();
                GameObject slash = Instantiate(smoke, cutter.transform.position, cutter.transform.rotation);
                Destroy(slash, 1f);
                setTrap = StartCoroutine(SetTrapAgain());
            }
        }
    }
    private IEnumerator SetTrapAgain()
    {
        yield return new WaitForSeconds(1f);
        isDecreased = false;
    }
    private void OnDestroy()
    {
        StopCoroutine(setTrap);
    }
}
