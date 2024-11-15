using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySkinButton : MonoBehaviour
{
    public Button useButton;
    public Button buyButton;
    public Button adsButton;
    public int idSkin;
    private Coroutine turnOff;
    public int currentCoin;
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.GetIdSkin, GetidSkin);
        currentCoin = GameControllManager.Ins.getcoin();
    }
    private void Start()
    {
        useButton.onClick?.AddListener(UseButton);
        buyButton.onClick?.AddListener(BuyButton);
        adsButton.onClick?.AddListener(AdsButton);
    }

    public void GetidSkin(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int id)) return;
        idSkin = id;
    }

    private void UseButton()
    {
        if (ViewCharacter.Ins.baseSkins[idSkin].isBuy)
        {
            ViewCharacter.Ins.SetStatusTextNoti(true, "ALREADY IN USE");
            GameControllManager.Ins.SetStatusSkin(ViewCharacter.Ins.skinsData.skinDatas[idSkin].NameCharacter, true, true);
            ViewCharacter.Ins.baseSkins[idSkin].isUse = true;
            for (int i = 0; i < ViewCharacter.Ins.baseSkins.Count; i++)
            {
                if (ViewCharacter.Ins.baseSkins[i].skinId == idSkin) continue;
                ViewCharacter.Ins.baseSkins[i].isUse = false;
                GameControllManager.Ins.SetStatusSkin(ViewCharacter.Ins.skinsData.skinDatas[idSkin].NameCharacter, true, false);
                Observer.Notify(UiAction.StatusUsed);
            }
        }
        else
        {
            ViewCharacter.Ins.SetStatusTextNoti(true, "YOU NEED TO PURCHASE THE SKIN FIRST");
        }
        turnOff = StartCoroutine(TurnOffText());
    }

    private void BuyButton()
    {
        if (currentCoin > ViewCharacter.Ins.skinsData.skinDatas[idSkin].price)
        {
            int coinIndex = currentCoin - ViewCharacter.Ins.skinsData.skinDatas[idSkin].price;
            GameControllManager.Ins.setcoin(coinIndex);
            Observer.Notify(UiAction.ChangeTextCoin, coinIndex);
            ViewCharacter.Ins.SetStatusTextNoti(true, "SUCCESSFULLY PURCHASED");
            GameControllManager.Ins.SetStatusSkin(ViewCharacter.Ins.skinsData.skinDatas[idSkin].NameCharacter, true, false);
            ViewCharacter.Ins.baseSkins[idSkin].isBuy = true;
            Observer.Notify(UiAction.StatusBuy);
        }
        else
        {
            ViewCharacter.Ins.SetStatusTextNoti(true, "YOU DON'T HAVE ENOUGH MONEY");
        }
        turnOff = StartCoroutine(TurnOffText());
    }
    IEnumerator TurnOffText()
    {
        yield return new WaitForSeconds(3f);
        ViewCharacter.Ins.SetStatusTextNoti(false, "");
        StopCoroutine(turnOff);
    }
    private void AdsButton()
    {

    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.GetIdSkin, GetidSkin);
    }
}
