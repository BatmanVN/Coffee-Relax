using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGame_UI : UICanvas
{
    [SerializeField] protected TextLevel textLevel;
    [SerializeField] protected TextMoneyConner textMoneyConner;
    [SerializeField] protected PauseBarManager pausedBarManager;
    [SerializeField] protected ButtonSettingInGame buttonSetting;
}
