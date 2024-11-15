using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : UICanvas
{
    public Button shopButton;
    public Button gachaButton;
    public Button dailyButton;
    public Button playButton;
    [Header("SkinData")]
    public SkinCharacterData skinDatas;
    private void Awake()
    {
        
    }
    private void Start()
    {
        playButton.onClick?.AddListener(PlayButton);  
        shopButton.onClick?.AddListener(ShopButton);
    }
    public void PlayButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<Swipe_UI>();
        Observer.Notify(ListAction.SpawnPlayer);
    }
    public void ShopButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<ShopUI>();
    }

}
