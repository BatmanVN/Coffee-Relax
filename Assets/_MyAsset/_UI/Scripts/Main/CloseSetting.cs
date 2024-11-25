using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSetting : MonoBehaviour
{
    public Button back;
    public ButtonSetting buttonSetting;

    private void Start()
    {
        back = GetComponent<Button>();
        back.onClick?.AddListener(BackMenu);
    }

    private void BackMenu()
    {
        buttonSetting.settingBar.gameObject.SetActive(false);
    }
}