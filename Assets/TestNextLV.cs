using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestNextLV : Win_UI
{
    public Button nextTestButton;

    private void OnEnable()
    {
        nextTestButton.onClick?.AddListener(NextLV);
        if(nextButton == null || adsButton == null ||
            txt_multi == null || coinTextConner == null)
            return;
    }

    private void NextLV()
    {
        GameControllManager.Ins.setLevel(GameControllManager.Ins.getlevel() + 1);
        Observer.Notify(ListAction.NextLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Close(0);
    }
}
