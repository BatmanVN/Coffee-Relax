
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllManager : Singleton<GameControllManager>
{
    //public static GameControllManager instance;

    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {

    }

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }

    //    onstartfirsttime();

    //}
    // Update is called once per frame
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

    public void onstartfirsttime()
    {
        if (!PlayerPrefs.HasKey("firsttime_genaral"))
        {
            PlayerPrefs.SetInt("level_general", 0);
            PlayerPrefs.SetInt("firsttime_genaral", 0);
            PlayerPrefs.SetFloat("coin", 0);

            for (int i = 1; i < 6; i++)
            {
                PlayerPrefs.SetInt("skin" + i, 0);
            }
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
    public float getcoin()
    {
        return PlayerPrefs.GetFloat("coin");
    }
    public void setcoin(float nbr)
    {
        PlayerPrefs.SetFloat("coin", nbr);
    }
    
}
