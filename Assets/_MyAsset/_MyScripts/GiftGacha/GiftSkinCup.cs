using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSkinCup : BaseGift
{
    [SerializeField] private int currentCoin;
    public override void GetPrize()
    {
        int random = Random.Range(1, GameControllManager.Ins.cupData.skinDatas.Count);
        if (GameControllManager.Ins.GetStatusBuySkin(GameControllManager.Ins.cupData.skinDatas[random].NameCup))
        {
            currentCoin = GameControllManager.Ins.getcoin();
            int total = currentCoin + moneyGift;
            GameControllManager.Ins.setcoin(total);
        }
        GameControllManager.Ins.SetStatusBuySkin(GameControllManager.Ins.cupData.skinDatas[random].NameCup, true);
        Debug.Log(prizeSegment);
    }
}
