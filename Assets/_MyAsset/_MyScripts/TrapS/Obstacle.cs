﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class Obstacle : MonoBehaviour
{
    Sequence sequence;
    public Vector3 pos;
    public float durations;
    public GameObject item_pref;
    public GameObject smoke_pref;
    public float power;
    public int countDrop;
    public int CupId_Use;
    // Start is called before the first frame update
    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                item_pref = cupSpawn.buckMap;
            }
        }
    }

    void Start()
    {
        transform.DOLocalMove(pos, durations).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    void Update()
    {
        transform.Rotate(Vector3.back * Time.smoothDeltaTime * 250);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            SoundManager.PlayIntSound(SoundType.TrapsSound, 7);

            Controller_Items.Ins.decrease_item();

            Vector3 tmp = transform.position;
            tmp.z += 4f;

            countDrop++;
            GameObject smoke = Instantiate(smoke_pref, other.transform.position, other.transform.rotation);
            Destroy(smoke,0.5f);
            if (countDrop < 2)
            {
                GameObject gm = Instantiate(item_pref, tmp, item_pref.transform.rotation);
                Vector3 shoot = new Vector3(0f, Random.Range(2, 5), Random.Range(2, 6));
                gm.GetComponent<Rigidbody>().AddForce(shoot * power, ForceMode.Impulse);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
            countDrop = 0;
    }
}
