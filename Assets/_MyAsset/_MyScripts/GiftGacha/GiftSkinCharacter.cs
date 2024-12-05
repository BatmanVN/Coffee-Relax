using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSkinCharacter : BaseGift
{
    [SerializeField] private int currentCoin;
    [field: SerializeField] public int skinCharacterID {  get; private set; }
    private void OnEnable()
    {
        currentCoin = GameControllManager.Ins.getcoin();
    }
    public override void GetPrize()
    {
        skinCharacterID = Random.Range(1, GameControllManager.Ins.characterData.skinDatas.Count);
        var chacDatas = GameControllManager.Ins.characterData.skinDatas[skinCharacterID];

        if (GameControllManager.Ins.GetStatusBuySkin(chacDatas.NameCharacter))
        {
            currentCoin = GameControllManager.Ins.getcoin();
            int total = currentCoin + moneyGift;
            GameControllManager.Ins.setcoin(total);
            Observer.Notify(WheelAction.UpdateCashCoiner, total);
            Observer.Notify(WheelAction.UsedItemRW, moneyGift, chacDatas.NameCharacter);
        }
        else
        {
            GameControllManager.Ins.SetStatusBuySkin(chacDatas.NameCharacter, true);
            Observer.Notify(WheelAction.RewardItem, chacDatas.sprite, chacDatas.NameCharacter);
        }
        SoundManager.PlayIntSound(SoundType.EarnRewardSpin, 0);
        Debug.Log(prizeSegment);
    }
}
