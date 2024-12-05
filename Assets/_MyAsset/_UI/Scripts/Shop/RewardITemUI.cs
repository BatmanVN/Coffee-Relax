using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardITemUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _itemRw;
    [SerializeField] private Text _CashItem;
    private void OnEnable()
    {
        Observer.AddObserver(WheelAction.RewardItem, SetRewardItemUI);
        Observer.AddObserver(WheelAction.UsedItemRW,SetRewardCashItemUI);
    }
    public void SetRewardItemUI(object[] datas)
    {
        _icon.gameObject.SetActive(true);
        _CashItem.gameObject.SetActive(false);
        if (datas == null || datas.Length < 1 ||
            !(datas[0] is Sprite icon) ||
            !(datas[1] is string itemRw)) return;
        _icon.sprite = icon;
        _itemRw.text = itemRw;
    }

    public void SetRewardCashItemUI(object[] datas)
    {
        _icon.gameObject.SetActive(false);
        _CashItem.gameObject.SetActive(true);
        if (datas == null || datas.Length < 1 ||
            !(datas[0] is int CashItem) ||
            !(datas[1] is string itemRw)) return;
        _CashItem.text = CashItem.ToString();
        _itemRw.text = itemRw;
    }

    private void OnDestroy()
    {
        Observer.RemoveObserver(WheelAction.RewardItem, SetRewardItemUI);
        Observer.RemoveObserver(WheelAction.UsedItemRW, SetRewardCashItemUI);
    }
}
