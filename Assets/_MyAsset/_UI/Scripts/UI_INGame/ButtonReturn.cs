using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonReturn : PauseBarManager
{
    public Button returnButton;
    private void OnValidate() => returnButton = GetComponent<Button>();
    private void Start()
    {
        returnButton.onClick?.AddListener(ReturnButton);
    }
    public void ReturnButton()
    {
        Time.timeScale = 1.0f;
        barManager.gameObject.SetActive(false);
        SoundManager.PlayIntSound(SoundType.StatusUI, 1);
    }
}
