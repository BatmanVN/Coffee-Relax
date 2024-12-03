using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTower : MonoBehaviour
{
    public static MoneyTower inst;
    public ListPosFinish posFinish;
    public Transform posPlayer;

    private void Awake()
    {
        if (inst != null && inst != this)
        {
            Destroy(gameObject);
            return;
        }
        inst = this;
    }
    private void OnEnable()
    {
        Observer.AddObserver(ActionInGame.MoneyTower, UpBonusMoney);
    }
    void Start()
    {
        
    }

    public void UpBonusMoney(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is Animator anim)) return;
        int targetIndex = Mathf.Clamp(Controller_Items.Ins.total_items, 0, posFinish.listPos.Count - 1);
        float targetY = posFinish.listPos[targetIndex].transform.position.y;
        transform.DOLocalMoveY(targetY, 6f)
                    .SetEase(Ease.OutExpo) // Hiệu ứng easing "tăng nhanh, giảm dần"
                    .OnComplete(() =>
                    {
                        CamFollow.Ins.ofsset = new Vector3(3.8f, 8f, -4f);
                        if (Controller_Items.Ins.total_items > 1)
                        {
                            Observer.Notify(ListAction.ChangeAnim, Const.victoryAnim);
                            SoundManager.PlaySound(SoundType.Victory);
                        }
                        if (Controller_Items.Ins.total_items <= 1)
                        {
                            //anim.SetTrigger(Const.cryAnim);
                            Observer.Notify(ListAction.ChangeAnim, Const.cryAnim);
                        }
                    });
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ActionInGame.MoneyTower,UpBonusMoney);
    }
}
