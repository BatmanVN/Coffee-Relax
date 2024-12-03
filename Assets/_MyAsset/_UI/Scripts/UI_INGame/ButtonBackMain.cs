using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBackMain : PauseBarManager
{
    public Button backButton;
    public string nameScene;
    private void OnValidate() => backButton = GetComponent<Button>();
    private void Start()
    {
        backButton.onClick?.AddListener(BackButton);
    }
    public void BackButton()
    {
        SoundManager.PlayIntSound(SoundType.StatusUI, 1);
        UIManager.Ins.CloseAll();
        Time.timeScale = 1.0f;
        UIManager.Ins.OpenUI<Loading>();
        SceneManager.LoadSceneAsync(nameScene);
    }
}
