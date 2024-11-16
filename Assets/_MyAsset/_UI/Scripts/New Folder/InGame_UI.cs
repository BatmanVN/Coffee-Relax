using MoreMountains.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGame_UI : UICanvas
{
    public Button setting;
    public Button returnButton;
    public Button backButton;
    public GameObject pauseBar;
    public GameObject upEffect;
    public Text txt_mmoney;
    public string nameScene;
    private Coroutine effect;
    private void OnEnable()
    {
        
        Observer.AddObserver(ListAction.Vibrate,_vibrate);
        Observer.AddObserver(ListAction.IncreaseMoney, increase_money);
        txt_mmoney.text = GameControllManager.Ins.getcoin().ToString();
    }
    private void Start()
    {
        setting.onClick?.AddListener(OpenSetting);
        returnButton.onClick?.AddListener(ReturnButton);
        backButton.onClick?.AddListener(BackButton);
    }

    public void BackButton()
    {
        Close(0);
        Time.timeScale = 1.0f;
        UIManager.Ins.OpenUI<MainMenu_UI>();
        //Observer.Notify(UiAction.SpawnModel);
        SceneManager.LoadSceneAsync(nameScene);
    }

    public void ReturnButton()
    {
        Time.timeScale = 1.0f;
        pauseBar.SetActive(false);
    }

    public void OpenSetting()
    {
        Time.timeScale = 0f;
        pauseBar.SetActive(true);
    }
    public void UpEffect(bool active)
    {
        upEffect.SetActive(active);
    }
    public void increase_money(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int nbr)) return;
        GameControllManager.Ins.setcoin(GameControllManager.Ins.getcoin() + nbr);
        txt_mmoney.text = GameControllManager.Ins.getcoin().ToString();
        UpEffect(true);
        effect = StartCoroutine(TurnOffEffect());
    }
    public IEnumerator TurnOffEffect()
    {
        yield return new WaitForSeconds(1);
        UpEffect(false);
        StopCoroutine(effect);
    }
    public void _vibrate(object[] datas)
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact, true, this);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.Vibrate, _vibrate);
        Observer.RemoveObserver(ListAction.IncreaseMoney, increase_money);
    }
}
