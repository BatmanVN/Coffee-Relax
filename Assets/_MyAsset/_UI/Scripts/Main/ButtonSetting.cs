using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : MonoBehaviour
{
    public GameObject settingBar;
    public Button buttonSetting;

    private void Start()
    {
        buttonSetting.onClick?.AddListener(ClickSetting);
    }

    private void ClickSetting()
    {
        settingBar.SetActive(true);
    }
}
