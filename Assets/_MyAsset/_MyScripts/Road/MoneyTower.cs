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

        // Gán instance hiện tại và đảm bảo không bị phá hủy.
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

        transform.DOLocalMoveY(targetY, 8f)
                    .SetEase(Ease.OutExpo) // Hiệu ứng easing "tăng nhanh, giảm dần"
                    .OnComplete(() =>
                    {
                        CamFollow.Ins.ofsset = new Vector3(3.8f, 9.5f, -4f);
                        if (Controller_Items.Ins.total_items > 1)
                        {
                            anim.SetTrigger(Const.victoryAnim);
                        }
                        if (Controller_Items.Ins.total_items <= 1)
                        {
                            anim.SetTrigger(Const.cryAnim);
                        }
                    });
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ActionInGame.MoneyTower,UpBonusMoney);
    }
}
