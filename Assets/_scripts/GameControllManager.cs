﻿
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    GamePlay,
    Setting,
    Win,
    Lose,
}
public class GameControllManager : Singleton<GameControllManager>
{

    //public GameObject[] levels;
    private static GameState gameState = GameState.MainMenu;

    public int levelCurrent;
    public int coinCurrent;
    public int skinIdUse;
    public int skinidCupUse;
    public SkinCharacterData characterData;
    public SkinCupData cupData;
    protected override void Awake()
    {
        base.Awake();
        Input.multiTouchEnabled = true;
        onstartfirsttime();
        ChangeState(GameState.MainMenu);
        UIManager.Ins.OpenUI<MainMenu_UI>();
    }
    void Start()
    {
        levelCurrent = getlevel();
        coinCurrent = getcoin();
        skinIdUse = GetIDSkinUse();
        skinidCupUse = GetIDSkinCupUse();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Delete All");
        }
    }


    //level
    public void setLevel(int lv)
    {
        PlayerPrefs.SetInt("level_general", lv);
    }
    public int getlevel()
    {
        return PlayerPrefs.GetInt("level_general");
    }

    // reset
    public void resetall()
    {
        PlayerPrefs.DeleteKey("firsttime_genaral");
        for (int i = 0; i < characterData.skinDatas.Count; i++)
        {
            PlayerPrefs.DeleteKey(characterData.skinDatas[i].NameCharacter + "Purchased");
            PlayerPrefs.DeleteKey("firsttime_genaral");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onstartfirsttime()
    {
        if (!PlayerPrefs.HasKey("firsttime_genaral"))
        {
            PlayerPrefs.SetInt("level_general", 0);
            PlayerPrefs.SetInt("firsttime_genaral", 0);
            PlayerPrefs.SetInt("coin", 100000);


            for (int i = 0; i < characterData.skinDatas.Count; i++)
            {
                if (i == 0)
                {
                    SetStatusBuySkin(characterData.skinDatas[0].NameCharacter, true);
                    SetIDSkinUse(0);
                }
                else
                {
                    SetStatusBuySkin(characterData.skinDatas[i].NameCharacter, false);
                }
            }
            for (int i= 0; i < cupData.skinDatas.Count; i++)
            {
                if (i == 0)
                {
                    SetStatusBuySkinCup(cupData.skinDatas[0].NameCup, true);
                    SetIDSkinCupUse(0);
                }
                else
                {
                    SetStatusBuySkinCup(cupData.skinDatas[i].NameCup, false);
                }
            }
        }
    }

    //Character Skin Data
    public void SetStatusBuySkin(string nameSkin, bool isBuy)
    {
        PlayerPrefs.SetInt(nameSkin + "Purchased", isBuy ? 1 : 0);
    }

    public void SetIDSkinUse(int skinID)
    {
        PlayerPrefs.SetInt("SkinID_Used", skinID);
    }
    public int GetIDSkinUse()
    {
        return PlayerPrefs.GetInt("SkinID_Used");
    }

    public bool GetStatusBuySkin(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Purchased", 0) == 1;
    }
    public bool GetStatusUseSkin(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Active", 0) == 1;
    }

    //Cup Skin Data
    public void SetStatusBuySkinCup(string nameSkin, bool isBuy)
    {
        PlayerPrefs.SetInt(nameSkin + "Purchased", isBuy ? 1 : 0);
    }
    public bool GetStatusBuySkinCup(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Purchased", 0) == 1;
    }
    public void SetIDSkinCupUse(int skinID)
    {
        PlayerPrefs.SetInt("Skin_CupID_Used", skinID);
    }
    public int GetIDSkinCupUse()
    {
        return PlayerPrefs.GetInt("Skin_CupID_Used");
    }

    //public bool CheckBuy(string nameSkin)
    //{
    //    return PlayerPrefs.GetInt(nameSkin + "Purchased", 0) == 1;
    //}
    //public void SetSkinID(int id)
    //{
    //    PlayerPrefs.SetInt("SkinId", id);
    //}
    //public int GetPlayerByID()
    //{
    //    return PlayerPrefs.GetInt("SkinID");
    //}
    // coin
    public int getcoin()
    {
        return PlayerPrefs.GetInt("coin");
    }
    public void setcoin(int nbr)
    {
        PlayerPrefs.SetInt("coin", nbr);
    }
    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }
}
