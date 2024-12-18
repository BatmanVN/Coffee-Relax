﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupObject : MonoBehaviour
{
    //public GameObject lipstick , mascara;
    public Item_type itemType;
    public Animator anim;
    private void OnValidate() => anim = GetComponent<Animator>();


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Const.playerTag) || collision.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            Destroy(gameObject);
            Controller_Items.Ins.Increase_item();
        }
    }
}
