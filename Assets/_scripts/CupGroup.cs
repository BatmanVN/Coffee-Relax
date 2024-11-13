using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CupGroup : GameUnit
{
    Sequence sequence;
    public Ease ease_bounce , ease_linear;
    public float time;
    public GameObject coffee;
    public GameObject iceCream;
    public GameObject lidCup;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.ShowCoffee, ShowCoffee);
        Observer.AddObserver(ListAction.ShowIceCream, ShowIceCream);
        Observer.AddObserver(ListAction.ShowLidCup, ShowLidCup);
    }
    public void animate_group_brush()
    {
        sequence = DOTween.Sequence();
        float pos_y_old = transform.localPosition.y;
        float pos_y_new = transform.localPosition.y + .5f;

        sequence

                    .Append(transform.DOLocalMoveY(pos_y_new, time).SetEase(ease_linear))
                    .Append(transform.DOLocalMoveY(pos_y_old, time).SetEase(ease_bounce));
    }

    public void ShowCoffee(object[] datas)
    {
        coffee.SetActive(true);
    }

    public void ShowIceCream(object[] datas)
    {
        iceCream.SetActive(true);
    }
    public void ShowLidCup(object[] datas)
    {
        lidCup.SetActive(true);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.ShowCoffee, ShowCoffee);
        Observer.RemoveObserver(ListAction.ShowIceCream, ShowIceCream);
        Observer.RemoveObserver(ListAction.ShowLidCup, ShowLidCup);
    }
}
