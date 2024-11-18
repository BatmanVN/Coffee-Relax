using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class ThornObstacle : MonoBehaviour
{

    public GameObject smoke_pref;
    public int countDrop;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            Controller_Items.Ins.decrease_item();

            GameObject smoke = Instantiate(smoke_pref, other.transform.position, other.transform.rotation);
            Destroy(smoke, 0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
            countDrop = 0;
    }
}
