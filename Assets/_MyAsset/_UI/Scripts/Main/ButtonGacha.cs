using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGacha : MonoBehaviour
{
    public Button gachaButton;
    void Start()
    {
        gachaButton.onClick?.AddListener(WheelButton);
    }

    public void WheelButton()
    {
        UIManager.Ins.OpenUI<LuckWheel>();
        SoundManager.PlaySound(SoundType.ClickButton);
    }
}
