using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTower : MonoBehaviour
{
    public static MoneyTower inst;
    public float timeMoveUp = 6f;
    public float timeStand = 3f;
    public ListPosFinish posFinish;
    public Transform posPlayer;
    public GameObject moneyEffects;

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
        if (Controller_Items.Ins.total_items >= 1)
        {
            transform.DOLocalMoveY(targetY, timeMoveUp)
                    .SetEase(Ease.OutExpo) // Hiệu ứng easing "tăng nhanh, giảm dần"
                    .OnComplete(() =>
                    {
                        Observer.Notify(ListAction.ChangeAnim, Const.victoryAnim);
                        SoundManager.PlaySound(SoundType.Victory);
                    });
        }
        if (Controller_Items.Ins.total_items < 1)
        {
            transform.DOLocalMoveY(targetY, timeStand)
                .SetEase(Ease.OutExpo) // Hiệu ứng easing "tăng nhanh, giảm dần"
                .OnComplete(() =>
            {
                Observer.Notify(ListAction.ChangeAnim, Const.cryAnim);
            });
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ActionInGame.MoneyTower, UpBonusMoney);
    }
}
