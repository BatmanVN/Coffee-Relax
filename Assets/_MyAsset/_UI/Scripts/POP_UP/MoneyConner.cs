using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyConner : MonoBehaviour
{
    [field: SerializeField] public int coinConner {  get; set; }
    public Text textCoin;
    private void OnEnable()
    {
        Observer.AddObserver(WheelAction.UpdateCashCoiner, SetTextCoin);
    }
    private void Start()
    {
        coinConner = GameControllManager.Ins.getcoin();
        textCoin.text = coinConner.ToString();
    }
    public void SetTextCoin(object[] datas)
    {
        if (datas == null || datas.Length <1 || !(datas[0] is int cash)) return;
        textCoin.text = cash.ToString();
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(WheelAction.UpdateCashCoiner,SetTextCoin);
    }
}
