using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardMoneyUI : MonoBehaviour
{
    [SerializeField] private Text _moneyRW;
    [SerializeField] private Text _textStatus;

    private void OnEnable()
    {
        Observer.AddObserver(WheelAction.RewardMoney, SetRewardItemUI);
    }
    public void SetRewardItemUI(object[] datas)
    {
        if (datas == null || datas.Length < 1 ||
            !(datas[0] is int moneyRW) ||
            !(datas[1] is string textStatus)) return;
        _moneyRW.text = moneyRW.ToString();
        _textStatus.text = textStatus;
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(WheelAction.RewardMoney, SetRewardItemUI);
    }
}
