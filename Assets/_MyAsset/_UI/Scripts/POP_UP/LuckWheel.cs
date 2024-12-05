using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class LuckWheel : UICanvas
{
    public Button backButton;
    void Start()
    {
        backButton.onClick?.AddListener(CloseWheel);
    }

    public void CloseWheel()
    {
        UIManager.Ins.OpenUI<MainMenu_UI>();
        UIManager.Ins.CloseUI<LuckWheel>();
        SoundManager.PlaySound(SoundType.ClickButton);
    }
}
