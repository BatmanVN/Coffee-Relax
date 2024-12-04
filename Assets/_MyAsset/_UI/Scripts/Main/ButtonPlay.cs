using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour, IPointerDownHandler
{
    public Button playButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayButton();
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
        SoundManager.PlaySound(SoundType.PlayButton);
    }
}
