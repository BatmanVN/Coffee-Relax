using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class BuySkinButton : BaseDownButton
{
    //public Button useButton;
    //public Button buyButton;
    public Toggle useButton;
    public Toggle buyButton;
    public Toggle usedButton;
    //[SerializeField] private bool firstOn;

    private void OnEnable()
    {
        Observer.AddObserver(UiAction.GetIdSkin, GetidSkin);
        Observer.AddObserver(UiAction.CheckUiUsed, CheckToggleStatus);
        currentCoin = GameControllManager.Ins.getcoin();
        SetToggleStatus(false, false, true);
    }
    private void Start()
    {
        useButton.onValueChanged?.AddListener(UseButton);
        buyButton.onValueChanged?.AddListener(BuyButton);
        usedButton.onValueChanged?.AddListener(UsedButton);
        adsButton.onClick?.AddListener(AdsButton);
    }

    private void SetToggleStatus(bool useActive, bool buyActive, bool usedActive)
    {
        useButton.gameObject.SetActive(useActive);
        buyButton.gameObject.SetActive(buyActive);
        usedButton.gameObject.SetActive(usedActive);
    }

    private void CheckToggleStatus(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int iDUsed)) return;
        if (iDUsed == GameControllManager.Ins.GetIDSkinUse())
        {
            SetToggleStatus(false, false, true);
        }
        else
            SetToggleStatus(false, false, false);
    }

    public void GetidSkin(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int id)) return;
        idSkin = id;
    }

    private void UseButton(bool active)
    {
        if (active)
        {
            SetToggleStatus(false, false, true);

            // Lấy tên skin từ dữ liệu của skin hiện tại (dựa trên idSkin)
            string nameSkin = ViewCharacter.Ins.skinsData.skinDatas[idSkin].NameCharacter;

            // Kiểm tra trạng thái đã mua skin hay chưa thông qua GameControllManager
            bool bought = GameControllManager.Ins.GetStatusBuySkin(nameSkin);

            // Nếu skin đã được mua
            if (bought)
            {

                // Cập nhật trạng thái sử dụng skin trong GameControllManager
                GameControllManager.Ins.SetIDSkinUse(idSkin);

                ViewCharacter.Ins.SetStatusTextNoti(true, ("SKIN " + ViewCharacter.Ins.baseSkins[idSkin].skinName + " HAS BEEN USED"));

                // Cập nhật thông tin về skin đang được sử dụng cho các đối tượng Observer
                Observer.Notify(UiAction.UpdateUsedObject, idSkin);
                SoundManager.PlaySound(SoundType.Used);
            }
            else
            {
                // Nếu chưa mua skin, hiển thị thông báo yêu cầu mua skin trước
                ShowNotification("YOU NEED TO PURCHASE THE SKIN FIRST");
            }

            turnOff = StartCoroutine(TurnOffText());
        }
        Debug.Log("Use: " + active);
    }

    private void UsedButton(bool active)
    {
        if (active)
        {
            int used = GameControllManager.Ins.GetIDSkinUse();
            ViewCharacter.Ins.SetStatusTextNoti(true, ("SKIN " + ViewCharacter.Ins.baseSkins[used].skinName + " HAS BEEN USED"));
            turnOff = StartCoroutine(TurnOffText());
            SoundManager.PlaySound(SoundType.Used);
        }
        Debug.Log("Used: " + active);
    }

    private void BuyButton(bool active)
    {
        if (active)
        {
            SetToggleStatus(false, true, false);
            // Kiểm tra xem người chơi có đủ tiền để mua skin không
            if (currentCoin > ViewCharacter.Ins.skinsData.skinDatas[idSkin].price)
            {
                // Tính toán số tiền còn lại sau khi mua skin
                int coinIndex = currentCoin - ViewCharacter.Ins.skinsData.skinDatas[idSkin].price;

                // Cập nhật số coin mới vào GameControllManager
                GameControllManager.Ins.setcoin(coinIndex);

                // Thông báo đến các UI (thay đổi số coin)
                Observer.Notify(UiAction.ChangeTextCoin, coinIndex);

                // Hiển thị thông báo thành công khi mua skin
                ViewCharacter.Ins.SetStatusTextNoti(true, "SUCCESSFULLY PURCHASED");

                // Cập nhật trạng thái đã mua skin trong GameControllManager
                GameControllManager.Ins.SetStatusBuySkin(ViewCharacter.Ins.skinsData.skinDatas[idSkin].NameCharacter, true);

                // Đánh dấu skin hiện tại là đã mua
                ViewCharacter.Ins.baseSkins[idSkin].isBuy = true;

                // Cập nhật trạng thái về skin đã sử dụng (nếu cần thiết)
                Observer.Notify(UiAction.StatusUsed);

                SoundManager.PlaySound(SoundType.BuySuccess);
            }
            else
            {
                // Nếu người chơi không đủ tiền, hiển thị thông báo không đủ tiền
                ViewCharacter.Ins.SetStatusTextNoti(true, "YOU DON'T HAVE ENOUGH MONEY");
            }
            // Khởi tạo Coroutine để tắt thông báo sau một khoảng thời gian
            turnOff = StartCoroutine(TurnOffText());
        }
        Debug.Log("Buy: " + active);
    }
    private void ShowNotification(string message)
    {
        ViewCharacter.Ins.SetStatusTextNoti(true, message);
    }

    IEnumerator TurnOffText()
    {
        yield return new WaitForSeconds(2f);
        ViewCharacter.Ins.SetStatusTextNoti(false, "");
        StopCoroutine(turnOff);
    }
    private void AdsButton()
    {

    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.GetIdSkin, GetidSkin);
        Observer.RemoveObserver(UiAction.CheckUiUsed, CheckToggleStatus);
    }
}
