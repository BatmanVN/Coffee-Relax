using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe_Button : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // Thực hiện hành động khi button được chạm
        hide_swipe_panel();
    }
    public void hide_swipe_panel()
    {
        Observer.Notify(ListAction.SetAimmator);
        Observer.Notify(ListAction.ChangeAnim, Const.runAnim);
        Observer.Notify(ListAction.GameRun, true);
        Observer.Notify(ListAction.SpawnObject);
        UIManager.Ins.OpenUI<InGame_UI>();
        UIManager.Ins.CloseUI<Swipe_UI>();
    }
}
