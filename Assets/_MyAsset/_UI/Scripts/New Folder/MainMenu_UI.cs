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
        onstartfirsttime();
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
    public void onstartfirsttime()
    {
        if (!PlayerPrefs.HasKey("firsttime_genaral"))
        {
            PlayerPrefs.SetInt("level_general", 0);
            PlayerPrefs.SetInt("firsttime_genaral", 0);
            PlayerPrefs.SetFloat("coin", 0);

            
            for (int i = 0; i < skinDatas.skinDatas.Count; i++)
            {
                PlayerPrefs.SetInt( skinDatas.skinDatas[i].NameCharacter, 0);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            for (int i = 0; i < skinDatas.skinDatas.Count; i++)
            {
                PlayerPrefs.DeleteKey(skinDatas.skinDatas[i].NameCharacter);
                PlayerPrefs.DeleteKey("firsttime_genaral");
            }
        }
    }
}
