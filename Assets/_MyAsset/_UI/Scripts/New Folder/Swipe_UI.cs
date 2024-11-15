using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_UI : UICanvas
{
    public Button swipeRun;
    private void Start()
    {
        swipeRun.onClick?.AddListener(hide_swipe_panel);
    }

    public void hide_swipe_panel()
    {
        Observer.Notify(ListAction.SetAimmator);
        Observer.Notify(ListAction.ChangeAnim, Const.runAnim);
        Observer.Notify(ListAction.GameRun, true);
        Observer.Notify(ListAction.SpawnObject);
        Close(0);
        UIManager.Ins.OpenUI<InGame_UI>();
    }
}
