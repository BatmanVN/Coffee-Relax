using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSkinCharacter : BaseGift
{
    [SerializeField] private int currentCoin;

    private void OnEnable()
    {
        currentCoin = GameControllManager.Ins.getcoin();
    }
    public override void GetPrize()
    {
        int random = Random.Range(1, GameControllManager.Ins.characterData.skinDatas.Count);
        if (GameControllManager.Ins.GetStatusBuySkin(GameControllManager.Ins.characterData.skinDatas[random].NameCharacter))
        {
            currentCoin = GameControllManager.Ins.getcoin();
            int total = currentCoin + moneyGift;
            GameControllManager.Ins.setcoin(total);
            Observer.Notify(WheelAction.UpdateCashCoiner, total);
        }
        GameControllManager.Ins.SetStatusBuySkin(GameControllManager.Ins.characterData.skinDatas[random].NameCharacter,true);
        Debug.Log(prizeSegment);
    }
}
