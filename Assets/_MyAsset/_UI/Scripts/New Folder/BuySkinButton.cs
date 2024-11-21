using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySkinButton : BaseDownButton
{
    public Button useButton;
    public Button buyButton;
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
            // Lấy tên skin từ dữ liệu của skin hiện tại (dựa trên idSkin)
            string nameSkin = ViewCharacter.Ins.skinsData.skinDatas[idSkin].NameCharacter;

            // Kiểm tra trạng thái đã mua skin hay chưa thông qua GameControllManager
            bool bought = GameControllManager.Ins.GetStatusBuySkin(nameSkin);

            // Nếu skin đã được mua
            if (bought)
            {
                // Hiển thị thông báo "ALREADY IN USE" cho người dùng
                ViewCharacter.Ins.SetStatusTextNoti(true, "ALREADY IN USE");

                // Cập nhật trạng thái sử dụng skin trong GameControllManager
                GameControllManager.Ins.SetIDSkinUse(idSkin);


                // Cập nhật thông tin về skin đang được sử dụng cho các đối tượng Observer
                Observer.Notify(UiAction.UpdateUsedObject, idSkin);
            }
            else
            {
                // Nếu chưa mua skin, hiển thị thông báo yêu cầu mua skin trước
                ShowNotification("YOU NEED TO PURCHASE THE SKIN FIRST");
            }

        turnOff = StartCoroutine(TurnOffText());
    }


    private void ShowNotification(string message)
    {
        ViewCharacter.Ins.SetStatusTextNoti(true, message);
    }

    private void BuyButton()
    {
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
            }
            else
            {
                // Nếu người chơi không đủ tiền, hiển thị thông báo không đủ tiền
                ViewCharacter.Ins.SetStatusTextNoti(true, "YOU DON'T HAVE ENOUGH MONEY");
            }


        // Khởi tạo Coroutine để tắt thông báo sau một khoảng thời gian
        turnOff = StartCoroutine(TurnOffText());
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
    }
}
