using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick?.AddListener(PlayButton);
    }

    public void PlayButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Loading>();
        Observer.Notify(ListAction.SpawnPlayer);
        Observer.Notify(ListAction.NextLevel);
        Observer.Notify(ActionInGame.SpawnRoad);
        Observer.Notify(ListAction.GetPrefabCupID);
        Observer.Notify(UiAction.MenuLoading);
    }
}
