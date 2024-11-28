using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOn : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject tornado;

    private Coroutine turnOff;

    private void OnTriggerEnter(Collider dubaCheck)
    {
        if (dubaCheck.CompareTag(Const.cupTag) || dubaCheck.CompareTag(Const.playerTag))
        {
            anim.SetTrigger(Const.wakeAnim);
            tornado.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
        {
            turnOff = StartCoroutine(TurnOff());
        }
    }


    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(5f);
        tornado.SetActive(false);
        StopCoroutine(turnOff);
    }
}
