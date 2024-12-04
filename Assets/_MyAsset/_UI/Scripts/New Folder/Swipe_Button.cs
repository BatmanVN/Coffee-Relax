using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe_Button : MonoBehaviour, IPointerDownHandler
{
    private bool isClick;
    private float time;
    private Coroutine setAnim;
    private void OnEnable()
    {
        BGMusic.PlayRandomSound(MusicType.Ingame);
    }
    private void Start()
    {
        setAnim = StartCoroutine(SetAnim());
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        hide_swipe_panel();
    }
    public void hide_swipe_panel()
    {
        isClick = true;
        SoundManager.PlaySound(SoundType.Swipe_Button);
        Observer.Notify(ListAction.SetAimmator);
        Observer.Notify(ListAction.ChangeAnim, Const.runAnim);
        Observer.Notify(ListAction.GameRun, true);
        Observer.Notify(ListAction.SpawnObject);
        Observer.Notify(ActionInGame.RotateStart);

        UIManager.Ins.OpenUI<InGame_UI>();
        UIManager.Ins.CloseUI<Swipe_UI>();
    }

    IEnumerator SetAnim()
    {
        while (true)
        {
            if (!isClick)
            {
                time += Time.deltaTime;
                Debug.Log(time);
            }
            if (time >= 5f)
            {
                int random = Random.Range(0, ConstDanceAnim.DanceList.Count);
                string anim = ConstDanceAnim.DanceList[random];
                Observer.Notify(ListAction.ChangeAnim, anim);
                time = 0;
                yield return new WaitForSeconds(3f);
            }
            yield return null;
        }
    }
    private void OnDestroy()
    {
        if(setAnim != null)
            StopCoroutine(setAnim);
    }
}
