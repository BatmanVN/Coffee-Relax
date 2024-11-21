using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkinCharacter : MonoBehaviour
{
    public SkinCharacterItemData characterData;

    public Button buttons;
    public bool isBuy;
    public GameObject used;
    public GameObject select;
    public int skinId;
    public string skinName;
    public int iDUsed;

    private void Awake()
    {
        characterData = ViewCharacter.Ins.skinsData.skinDatas.Find(data => data.id == skinId);
        skinName = characterData.NameCharacter;
        isBuy = GameControllManager.Ins.GetStatusBuySkin(characterData.NameCharacter);
        iDUsed = GameControllManager.Ins.GetIDSkinUse();
    }
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.UpdateUsedObject, UpdateUsedObject);
        SetStatusUiSkin();
    }

    private void Start()
    {
        if (characterData == null)
        {
            Debug.LogError($"SkinCharacterData not found for skinId: {skinId}");
            return;
        }
        buttons = GetComponent<Button>();
        buttons.onClick?.AddListener(() => InsCharacter(skinId));
    }

    //Kiểm tra đang sử dụng skin nào, để hiển thị model skin đó
    protected void SetStatusUiSkin()
    {
        if (skinId == iDUsed)
        {
            ViewCharacter.Ins.currentSkin = Instantiate(characterData.character_pref, ViewCharacter.Ins.spawnPoint.position, ViewCharacter.Ins.spawnPoint.rotation);
            ViewCharacter.Ins.currentSkin.transform.SetParent(ViewCharacter.Ins.spawnPoint.transform);
            ViewCharacter.Ins.useButton.SetActive(skinId == iDUsed);
            ViewCharacter.Ins.buyButton.SetActive(skinId != iDUsed);
            ViewCharacter.Ins.currentSelect = this;
            select.SetActive(true);
        }
        else
            select.gameObject.SetActive(false);
        used.SetActive(skinId == iDUsed);
    }
    private void InsCharacter(int currentID)
    {
        // Kiểm tra trạng thái mua skin từ PlayerPrefs
        isBuy = GameControllManager.Ins.GetStatusBuySkin(characterData.NameCharacter);
        iDUsed = GameControllManager.Ins.GetIDSkinUse();
        Observer.Notify(UiAction.GetIdSkin, skinId);

        //Check đang bấm skin nào để hiện bo viền
        if(ViewCharacter.Ins.currentSelect != null)
            ViewCharacter.Ins.currentSelect.select.SetActive(false);
        ViewCharacter.Ins.currentSelect = this;
        select.SetActive(true);

        //instance prefab character tương ứng để hiển thị và tắt character trước
        GameObject character = Instantiate(characterData.character_pref, ViewCharacter.Ins.spawnPoint.position, ViewCharacter.Ins.spawnPoint.rotation);
        character.transform.SetParent(ViewCharacter.Ins.spawnPoint.transform);
        Observer.Notify(UiAction.DestroySkin);
        ViewCharacter.Ins.buttonDown.SetActive(true);
        ViewCharacter.Ins.currentSkin = character;
        UpdateBuyStatusUI(currentID);
    }

    // Cập nhật trạng thái hiển thị nút sử dụng hoặc mua
    private void UpdateBuyStatusUI(int currentID)
    {
        if (!isBuy)
        {
            // Nếu chưa mua skin, hiển thị nút mua và giá
            Observer.Notify(UiAction.StatusBuy);
            ViewCharacter.Ins.textPrice.text = ViewCharacter.Ins.skinsData.skinDatas[currentID].price.ToString();
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
        iDUsed = GameControllManager.Ins.GetIDSkinUse();
        if(skin == skinId)
            used.SetActive(skinId == iDUsed);
        else
            used.SetActive(false);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.UpdateUsedObject, UpdateUsedObject);
    }
}
