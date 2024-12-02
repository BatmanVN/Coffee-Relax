using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShop : MonoBehaviour
{
    public Button shopButton;
    void Start()
    {
        shopButton.onClick?.AddListener(ShopButton);
    }
    public void ShopButton()
    {
        SoundManager.PlaySound(SoundType.ClickButton);
        UIManager.Ins.CloseAll();
        //UIManager.Ins.CloseUI<MainMenu_UI>();
        UIManager.Ins.OpenUI<ShopUI>();
    }
}
