using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandTrap : MonoBehaviour
{
    public GameObject smoke_pref;
    private bool isDecreased;
    public float speed;
    private void Start()
    {
        MoveHand();
    }
    public void MoveHand()
    {
        this.gameObject.transform.DOLocalMoveY(-13f, speed).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter(Collider hand)
    {
        if (hand.CompareTag(Const.cupTag) || hand.CompareTag(Const.playerTag))
        {
            if (!isDecreased)
            {
                Observer.Notify(ListAction.Vibrate);

                Controller_Items.Ins.decrease_item();

                GameObject smoke = Instantiate(smoke_pref, hand.transform.position, hand.transform.rotation);
                Destroy(smoke, 1f);
            }
        }
    }
    private void OnTriggerExit(Collider hand)
    {
        if (hand.CompareTag(Const.cupTag) || hand.CompareTag(Const.playerTag))
        {
            isDecreased = true;
        }
    }
}
