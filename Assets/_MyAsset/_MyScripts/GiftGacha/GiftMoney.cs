using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMoney : BaseGift
{
    private const string earnGift = "CONGRATULATIONS";
    private const string loseGift = "!HA HA HA HA!";
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
        if (typeGift == TypeGift.LoseGift)
        {
            Observer.Notify(WheelAction.RewardMoney, moneyGift, loseGift);
            SoundManager.PlayIntSound(SoundType.EarnRewardSpin, 1);
        }
        if (typeGift == TypeGift.MoneyGift)
        {
            Observer.Notify(WheelAction.RewardMoney, moneyGift, earnGift);
            SoundManager.PlayIntSound(SoundType.EarnRewardSpin, 0);
        }
    }
}
