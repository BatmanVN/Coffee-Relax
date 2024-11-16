using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Win_UI : UICanvas
{
    public Text txt_multi;
    public Text coinTextConner;
    public Button nextButton;
    public Button adsButton;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.FinishGame,show_multiplication);
        coinTextConner.text = GameControllManager.Ins.getcoin().ToString();
    }
    public void Start()
    {
        nextButton.onClick?.AddListener(btn_next);
        adsButton.onClick?.AddListener(AdsButton);
    }

    public void AdsButton()
    {
        
    }

    public void btn_next()
    {
        //Advertisements.Instance.ShowInterstitial();

        // sound
        //SoundManager.instance.Play("click");

        GameControllManager.Ins.setLevel(GameControllManager.Ins.getlevel() + 1);
        Observer.Notify(ListAction.NextLevel);
        //Observer.Notify(UiAction.SpawnModel);
        Observer.Notify(ActionInGame.DisableRoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Close(0);
        UIManager.Ins.OpenUI<Swipe_UI>();
    }
    public void show_multiplication(object[] datas)
    {
        if(datas == null || datas.Length < 1 || !(datas[0] is int nbr)) return;
        txt_multi.text = nbr + " ×";
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.FinishGame, show_multiplication);
    }
}
