using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe_Button : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        hide_swipe_panel();
    }
    public void hide_swipe_panel()
    {
        Observer.Notify(ListAction.SetAimmator);
        Observer.Notify(ListAction.ChangeAnim, Const.runAnim);
        Observer.Notify(ListAction.GameRun, true);
        Observer.Notify(ListAction.SpawnObject);
        Observer.Notify(ActionInGame.RotateStart);

        UIManager.Ins.OpenUI<InGame_UI>();
        UIManager.Ins.CloseUI<Swipe_UI>();
    }
}
