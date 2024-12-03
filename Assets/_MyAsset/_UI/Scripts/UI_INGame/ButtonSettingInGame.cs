using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettingInGame : MonoBehaviour
{
    public Button setting;
    public PauseBarManager pauseBarManager;
    private void OnValidate()
    {
        setting = GetComponent<Button>();
    }
    private void Start()
    {
        setting.onClick?.AddListener(OpenSetting);
    }

    public void OpenSetting()
    {
        Time.timeScale = 0f;
        pauseBarManager.gameObject.SetActive(true);
        SoundManager.PlayIntSound(SoundType.StatusUI, 0);
    }
}
