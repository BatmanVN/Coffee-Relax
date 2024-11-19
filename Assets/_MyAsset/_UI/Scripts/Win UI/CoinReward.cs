using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinReward : MonoBehaviour
{
    public Text coinReward;
    

    private void Start()
    {
        ChangeTextValue();
    }
    public void ChangeTextValue()
    {
        coinReward.text = FinishLevel.Ins.totalCoin.ToString();
    }
}
