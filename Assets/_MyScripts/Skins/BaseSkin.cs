using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkin : MonoBehaviour
{
    public SkinCharacterItemData characterData;

    public Button buttons;
    public bool isBuy;
    public bool isUse;
    public GameObject used;
    public int skinId;
    public string skinName;
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.UpdateUsedObject, UpdateUsedObject);
        characterData = ViewCharacter.Ins.skinsData.skinDatas.Find(data => data.id == skinId);
        skinName = characterData.NameCharacter;
        isBuy = GameControllManager.Ins.GetStatusBuySkin(characterData.NameCharacter);
        isUse = GameControllManager.Ins.GetStatusUseSkin(characterData.NameCharacter);
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
    private void InsCharacter(int currentID)
    {
        // Kiểm tra trạng thái mua skin từ PlayerPrefs
        isBuy = GameControllManager.Ins.GetStatusBuySkin(characterData.NameCharacter);
        isUse = GameControllManager.Ins.GetStatusUseSkin(characterData.NameCharacter);
        Observer.Notify(UiAction.GetIdSkin, skinId);

        //instance prefab character tương ứng để hiển thị và tắt character trước
        GameObject character = Instantiate(characterData.character_pref, ViewCharacter.Ins.spawnPoint.position, ViewCharacter.Ins.spawnPoint.rotation);
        character.transform.SetParent(ViewCharacter.Ins.spawnPoint.transform);
        Destroy(ViewCharacter.Ins.currentSkin);

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
    private void UpdateUsedObject(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is string nameSkin)) return;
        if (nameSkin == skinName)
        {
            if (!isUse)
                used.SetActive(false);
            else used.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.UpdateUsedObject, UpdateUsedObject);
    }
}
