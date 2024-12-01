using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMoney : BaseGift
{
    [SerializeField] private int currentCoin;
    private void OnEnable()
    {
        currentCoin = GameControllManager.Ins.getcoin();
    }
    public override void GetPrize()
    {
        int total = currentCoin + moneyGift;
        GameControllManager.Ins.setcoin(total);
        Debug.Log(prizeSegment + 1);
        Observer.Notify(WheelAction.UpdateCashCoiner, total);
    }
}
