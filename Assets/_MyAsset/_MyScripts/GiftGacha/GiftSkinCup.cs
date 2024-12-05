using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSkinCup : BaseGift
{

    [SerializeField] private int currentCoin;
    [field: SerializeField] public int skinCupID { get; private set; }
    public override void GetPrize()
    {
        skinCupID = Random.Range(1, GameControllManager.Ins.cupData.skinDatas.Count);
        var cupDatas = GameControllManager.Ins.cupData.skinDatas[skinCupID];
        if (GameControllManager.Ins.GetStatusBuySkin(cupDatas.NameCup))
        {
            currentCoin = GameControllManager.Ins.getcoin();
            int total = currentCoin + moneyGift;
            GameControllManager.Ins.setcoin(total);
            Observer.Notify(WheelAction.UpdateCashCoiner, total);
            Observer.Notify(WheelAction.UsedItemRW, moneyGift, cupDatas.NameCup);
        }
        else
        {
            GameControllManager.Ins.SetStatusBuySkin(cupDatas.NameCup, true);
            Observer.Notify(WheelAction.RewardItem, cupDatas.sprite, cupDatas.NameCup);
        }

        Debug.Log(prizeSegment);
    }
}
