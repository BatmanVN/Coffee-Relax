
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

    protected override void Awake()
    {
        base.Awake();
        Input.multiTouchEnabled = true;

        ChangeState(GameState.MainMenu);
        UIManager.Ins.OpenUI<MainMenu_UI>();

        //onstartfirsttime();
    }
    void Start()
    {
        levelCurrent = getlevel();
        coinCurrent = getcoin();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            setcoin(5000);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            resetall();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //setLevel(getlevel() + 1);
            //if (levels.Length <= getlevel() + 1)
            //    return;
            setLevel(getlevel() + 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    public int GetSkinIndex()
    {
        return PlayerPrefs.GetInt("SkinsID");
    }
    public void SetSkin(int idSkin)
    {
        PlayerPrefs.SetInt("SkinsID",idSkin);
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
