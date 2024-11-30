﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomCash : BaseRandomGate
{
    private List<int> listCash = new List<int>()
        {
            0, 10, 20, 40, 60, 80, 100, 150, 200, -10, -20, -40, -60, -80, -100,-150,-200
        };

    [SerializeField] private TextMeshProUGUI textRandom;
    [SerializeField] private int randomIndex;
    private bool isSetted;
    private Coroutine randomCash;
    private Coroutine changeText;

    private void Start()
    {
        randomCash = StartCoroutine(RanDomCash());
    }

    private void OnTriggerEnter(Collider randomGate)
    {
        if (randomGate.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            CupGroup cupGroup = randomGate.GetComponent<CupGroup>();
            if (cupGroup == null) return;
            SetRandomCash(cupGroup);
            isSetted = true;
            StopCoroutine(randomCash);
            Time.timeScale = 0.7f;
            changeText = StartCoroutine(JokePlayer());
        }
    }

    protected void SetRandomCash(CupGroup cupGroup)
    {
        foreach (CupType cupType in cupGroup.cupTypes)
        {
            if (cupGroup.item_Type == cupType.item_Type &&
                cupType.gameObject.activeSelf &&
                cupType.item_Type != Item_type.Cup)
            {
                cupType.money = listCash[randomIndex];
                cupGroup.animate_group_item();
            }
        }
    }
    protected IEnumerator RanDomCash()
    {
        while (!isSetted)
        {
            randomIndex = UnityEngine.Random.Range(0, listCash.Count);
            textRandom.text = listCash[randomIndex].ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }

    protected IEnumerator JokePlayer()
    {
        yield return new WaitForSeconds(1.6f);
        Time.timeScale = 1f;
        if (listCash[randomIndex] <= 0)
        {
            textRandom.text = "HA HA HA";
            textRandom.color = Color.red;
        }
        if (listCash[randomIndex] > 0)
        {
            textRandom.text = "NICE!";
            textRandom.color = Color.yellow;
        }
        StopCoroutine(changeText);
    }
}
