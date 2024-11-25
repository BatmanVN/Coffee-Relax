using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyConner : MonoBehaviour
{
    [field: SerializeField] public int coinConner {  get; set; }
    public Text textCoin;

    private void Start()
    {
        coinConner = GameControllManager.Ins.getcoin();
        textCoin.text = coinConner.ToString();
    }
}
