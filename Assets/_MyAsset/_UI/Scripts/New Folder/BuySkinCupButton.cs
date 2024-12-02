using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySkinCupButton : BaseDownButton
{
    public Button useButton;
    public Button buyButton;
    public Button usedButton;
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.CheckUiCup, CheckToggleStatus);
        Observer.AddObserver(UiAction.GetIdSkinCup, GetidSkinCup);
        currentCoin = GameControllManager.Ins.getcoin();
        SetToggleStatus(false, false, true);
    }
    private void Start()
    {
        useButton.onClick?.AddListener(UseButton);
        buyButton.onClick?.AddListener(BuyButton);
        usedButton.onClick?.AddListener(UsedButton);
        adsButton.onClick?.AddListener(AdsButton);
    }

    public void GetidSkinCup(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int id)) return;
        idSkin = id;
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
        if (iDUsed == GameControllManager.Ins.GetIDSkinCupUse())
        {
            SetToggleStatus(false, false, true);
        }
        else
            SetToggleStatus(false, false, false);
    }

    private void UseButton()
    {
        SetToggleStatus(false, false, true);
        // Lấy tên skin từ dữ liệu của skin hiện tại (dựa trên idSkin)
        string nameSkin = ViewSkinCup.Ins.skinsData.skinDatas[idSkin].NameCup;

        // Kiểm tra trạng thái đã mua skin hay chưa thông qua GameControllManager
        bool bought = GameControllManager.Ins.GetStatusBuySkinCup(nameSkin);

        // Nếu skin đã được mua
        if (bought)
        {
            // Hiển thị thông báo "ALREADY IN USE" cho người dùng
            ViewSkinCup.Ins.SetStatusTextNoti(true, "ALREADY IN USE");

            // Cập nhật trạng thái sử dụng skin trong GameControllManager
            GameControllManager.Ins.SetIDSkinCupUse(idSkin);

            //Observer.Notify(ListAction.GetPrefabCupID);

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
    private void UsedButton()
    {

        int used = GameControllManager.Ins.GetIDSkinCupUse();
        ViewCharacter.Ins.SetStatusTextNoti(true, ("SKIN HAS BEEN USED"));
        SoundManager.PlaySound(SoundType.Used);
        turnOff = StartCoroutine(TurnOffText());
    }


    private void BuyButton()
    {
        SetToggleStatus(false, true, false);
        if (currentCoin > ViewSkinCup.Ins.skinsData.skinDatas[idSkin].price)
        {
            // Tính toán số tiền còn lại sau khi mua skin
            int coinIndex = currentCoin - ViewSkinCup.Ins.skinsData.skinDatas[idSkin].price;

            // Cập nhật số coin mới vào GameControllManager
            GameControllManager.Ins.setcoin(coinIndex);

            // Thông báo đến các UI (thay đổi số coin)
            Observer.Notify(UiAction.ChangeTextCoin, coinIndex);

            // Hiển thị thông báo thành công khi mua skin
            ViewSkinCup.Ins.SetStatusTextNoti(true, "SUCCESSFULLY PURCHASED");

            // Cập nhật trạng thái đã mua skin trong GameControllManager
            GameControllManager.Ins.SetStatusBuySkinCup(ViewSkinCup.Ins.skinsData.skinDatas[idSkin].NameCup, true);

            // Đánh dấu skin hiện tại là đã mua
            ViewSkinCup.Ins.baseSkins[idSkin].isBuy = true;

            // Cập nhật trạng thái về skin đã sử dụng (nếu cần thiết)
            Observer.Notify(UiAction.StatusUsed);

            SoundManager.PlaySound(SoundType.BuySuccess);
        }
        else
        {
            // Nếu người chơi không đủ tiền, hiển thị thông báo không đủ tiền
            ViewSkinCup.Ins.SetStatusTextNoti(true, "YOU DON'T HAVE ENOUGH MONEY");
        }

        // Khởi tạo Coroutine để tắt thông báo sau một khoảng thời gian
        turnOff = StartCoroutine(TurnOffText());
    }

    private void ShowNotification(string message)
    {
        ViewSkinCup.Ins.SetStatusTextNoti(true, message);
    }


    IEnumerator TurnOffText()
    {
        yield return new WaitForSeconds(2f);
        ViewSkinCup.Ins.SetStatusTextNoti(false, "");
        StopCoroutine(turnOff);
    }
    private void AdsButton()
    {

    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.GetIdSkinCup, GetidSkinCup);
        Observer.RemoveObserver(UiAction.CheckUiCup, CheckToggleStatus);
    }
}
