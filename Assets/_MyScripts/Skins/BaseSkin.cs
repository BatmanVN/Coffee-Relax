using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkin : MonoBehaviour
{
    public Button buttons;
    public bool isBuy;
    public bool isUse;
    public GameObject used;
    public int skinId;
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.StatusUsed, SetStatusUsed);
        Observer.AddObserver(UiAction.StatusBuy, SetStatusBuy);
    }
    private void Start()
    {
        buttons = GetComponent<Button>();
        buttons.onClick?.AddListener(() => InsCharacter(skinId));
    }
    private void InsCharacter(int currentID)
    {
        Observer.Notify(UiAction.GetIdSkin, skinId);
        GameObject character = Instantiate(ViewCharacter.Ins.skinsData.skinDatas[currentID].character_pref, ViewCharacter.Ins.spawnPoint.position, ViewCharacter.Ins.spawnPoint.rotation);
        character.transform.SetParent(ViewCharacter.Ins.spawnPoint.transform);
        Destroy(ViewCharacter.Ins.currentSkin);
        ViewCharacter.Ins.buttonDown.SetActive(true);
        ViewCharacter.Ins.currentSkin = character;
        if (!isBuy)
        {
            ViewCharacter.Ins.useButton.SetActive(false);
            ViewCharacter.Ins.buyButton.SetActive(true);
            ViewCharacter.Ins.textPrice.text = ViewCharacter.Ins.skinsData.skinDatas[currentID].price.ToString();
        }
        else
        {
            ViewCharacter.Ins.useButton.SetActive(true);
            ViewCharacter.Ins.buyButton.SetActive(false);
        }
    }
    public void SetStatusBuy(object[] datas)
    {
        ViewCharacter.Ins.useButton.SetActive(true);
        ViewCharacter.Ins.buyButton.SetActive(false);
    }
    public void SetStatusUsed(object[] datas)
    {
        ViewCharacter.Ins.useButton.SetActive(false);
        ViewCharacter.Ins.buyButton.SetActive(true);
        if(isUse)
            used.SetActive(true);
        else
            used.SetActive(false);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.StatusUsed, SetStatusUsed);
        Observer.RemoveObserver(UiAction.StatusBuy, SetStatusBuy);
    }
}
