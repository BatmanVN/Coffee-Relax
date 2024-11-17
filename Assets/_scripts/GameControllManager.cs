
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
    public int skinId;
    public SkinCharacterData characterData;
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
        //Observer.Notify(UiAction.SpawnModel);
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    setcoin(5000);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    resetall();
        //}

        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    //setLevel(getlevel() + 1);
        //    //if (levels.Length <= getlevel() + 1)
        //    //    return;
        //    setLevel(getlevel() + 1);

        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    for (int i = 0; i < characterData.skinDatas.Count; i++)
        //    {
        //        if (i == 0)
        //        {
        //            SetStatusBuySkin(characterData.skinDatas[0].NameCharacter, true);
        //            SetStatusUseSkin(characterData.skinDatas[0].NameCharacter, true);
        //        }
        //        else
        //        {
        //            SetStatusBuySkin(characterData.skinDatas[i].NameCharacter, false);
        //            SetStatusUseSkin(characterData.skinDatas[i].NameCharacter, false);
        //        }
        //    }
        //    Debug.Log("Delete Key Skin"); 
        //}
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
            PlayerPrefs.DeleteKey(characterData.skinDatas[i].NameCharacter + "Active");
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
                    SetStatusUseSkin(characterData.skinDatas[0].NameCharacter, true);
                }
                else
                {
                    SetStatusBuySkin(characterData.skinDatas[i].NameCharacter, false);
                    SetStatusUseSkin(characterData.skinDatas[i].NameCharacter, false);
                }
            }
        }
    }
    public void SetStatusBuySkin(string nameSkin, bool isBuy)
    {
        PlayerPrefs.SetInt(nameSkin + "Purchased", isBuy ? 1 : 0);
    }
    public void SetStatusUseSkin(string nameSkin, bool isActive)
    {
        PlayerPrefs.SetInt(nameSkin + "Active", isActive ? 1 : 0);
    }
    public bool GetStatusBuySkin(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Purchased", 0) == 1;
    }
    public bool GetStatusUseSkin(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Active", 0) == 1;
    }
    public bool CheckBuy(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Purchased", 0) == 1;
    }
    public bool CheckUse(string nameSkin)
    {
        return PlayerPrefs.GetInt(nameSkin + "Active", 0) == 1;
    }
    public void SetSkinID(int id)
    {
        PlayerPrefs.SetInt("SkinId", id);
    }
    public int GetPlayerByID()
    {
        return PlayerPrefs.GetInt("SkinID");
    }
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
