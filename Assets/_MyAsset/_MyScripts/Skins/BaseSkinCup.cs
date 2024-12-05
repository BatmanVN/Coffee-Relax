using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkinCup : MonoBehaviour
{
    public SkinCupItemData skinCupItemData;

    public Button buttons;
    public bool isBuy;
    public Used used;
    public Select select;
    public int skinId;
    public string skinName;
    public int iDUsed;

    private void Awake()
    {
        skinCupItemData = ViewSkinCup.Ins.skinsData.skinDatas.Find(data => data.id == skinId);
        skinName = skinCupItemData.NameCup;
        isBuy = GameControllManager.Ins.GetStatusBuySkinCup(skinCupItemData.NameCup);
        iDUsed = GameControllManager.Ins.GetIDSkinCupUse();
    }
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.UpdateUsedObject, UpdateUsedObject);
        SetStatusUiSkin();
    }

    private void Start()
    {
        if (skinCupItemData == null)
        {
            Debug.LogError($"SkinCupData not found for skinId: {skinId}");
            return;
        }
        buttons = GetComponent<Button>();
        buttons.onClick?.AddListener(() => InsCup(skinId));
    }

    //Kiểm tra đang sử dụng skin nào, để hiển thị model skin đó
    protected void SetStatusUiSkin()
    {
        Observer.Notify(UiAction.CheckUiCup);
        if (skinId == iDUsed)
        {
            ViewSkinCup.Ins.currentSkin = Instantiate(skinCupItemData.buckMap, ViewSkinCup.Ins.spawnPoint.position, ViewSkinCup.Ins.spawnPoint.rotation);
            ViewSkinCup.Ins.currentSkin.transform.SetParent(ViewSkinCup.Ins.spawnPoint.transform);
            ViewSkinCup.Ins.useButton.SetActive(skinId == iDUsed);
            ViewSkinCup.Ins.buyButton.SetActive(skinId != iDUsed);
            ViewSkinCup.Ins.currentSelect = this;
            select.gameObject.SetActive(true);
        }
        else
            select.gameObject.SetActive(false);
        used.gameObject.SetActive(skinId == iDUsed);
    }
    private void InsCup(int currentID)
    {
        // Kiểm tra trạng thái mua skin từ PlayerPrefs
        isBuy = GameControllManager.Ins.GetStatusBuySkinCup(skinCupItemData.NameCup);
        iDUsed = GameControllManager.Ins.GetIDSkinCupUse();
        Observer.Notify(UiAction.GetIdSkinCup, skinId);
        Observer.Notify(UiAction.CheckUiCup);

        //Check đang bấm skin nào để hiện bo viền
        if (ViewSkinCup.Ins.currentSelect != null)
            ViewSkinCup.Ins.currentSelect.select.gameObject.SetActive(false);
            ViewSkinCup.Ins.currentSelect = this;
        select.gameObject.SetActive(true);

        //instance prefab character tương ứng để hiển thị và tắt character trước
        GameObject cup = Instantiate(skinCupItemData.buckMap, ViewSkinCup.Ins.spawnPoint.position, ViewSkinCup.Ins.spawnPoint.rotation);
        cup.transform.SetParent(ViewSkinCup.Ins.spawnPoint.transform);
        Observer.Notify(UiAction.DestroySkin);
        ViewSkinCup.Ins.buttonDown.SetActive(true);
        ViewSkinCup.Ins.currentSkin = cup;
        UpdateBuyStatusUI(currentID);
        SoundManager.PlaySound(SoundType.ClickButton);
    }

    // Cập nhật trạng thái hiển thị nút sử dụng hoặc mua
    private void UpdateBuyStatusUI(int currentID)
    {
        if (!isBuy)
        {
            // Nếu chưa mua skin, hiển thị nút mua và giá
            Observer.Notify(UiAction.StatusBuy);
            ViewSkinCup.Ins.textPrice.text = ViewSkinCup.Ins.skinsData.skinDatas[currentID].price.ToString();
        }
        else
        {
            // Nếu đã mua skin, hiển thị nút sử dụng và ẩn nút mua
            Observer.Notify(UiAction.StatusUsed);
        }
    }
    //Kiểm tra ấn sử dụng skin nào thì skin đó sẽ hiển thị đã sử dụng
    private void UpdateUsedObject(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int skin)) return;
        iDUsed = GameControllManager.Ins.GetIDSkinCupUse();
        if (skin == skinId)
            used.gameObject.SetActive(skinId == iDUsed);
        else
            used.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.UpdateUsedObject, UpdateUsedObject);
    }
}
