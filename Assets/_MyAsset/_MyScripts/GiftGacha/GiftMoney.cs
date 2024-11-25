using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMoney : BaseGift
{
    [SerializeField] private int currentCoin;
    private void OnEnable()
    {
        
    }
    public override void GetPrize()
    {
        currentCoin = GameControllManager.Ins.getcoin();
        int total = currentCoin + moneyGift;
        GameControllManager.Ins.setcoin(total);
        Debug.Log(prizeSegment);
    }
}
