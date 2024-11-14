using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CupGroup : GameUnit
{
    Sequence sequence;
    public Ease ease_bounce, ease_linear;
    public float time;
    public List<CupType> cupTypes;
    public Item_type item_Type;
    private void OnEnable()
    {
        //Observer.AddObserver(ListAction.ShowCoffee, ShowCoffee);
        //Observer.AddObserver(ListAction.ShowIceCream, ShowIceCream);
        //Observer.AddObserver(ListAction.ShowLidCup, ShowLidCup);
        //Observer.AddObserver(ListAction.ShowIce7, ShowIce7Color);
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            cupTypes.Add(child.GetComponent<CupType>());
        }
    }
    public void animate_group_item()
    {
        sequence = DOTween.Sequence();
        float pos_y_old = transform.localPosition.y;
        float pos_y_new = transform.localPosition.y + .5f;

        sequence

                    .Append(transform.DOLocalMoveY(pos_y_new, time).SetEase(ease_linear))
                    .Append(transform.DOLocalMoveY(pos_y_old, time).SetEase(ease_bounce));
    }

    //public void ShowCoffee(object[] datas)
    //{
    //    if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
    //    CupType coffee = cupTypes.Find(x => x.item_Type == Item_type.Cup);
    //    if (coffee != null)
    //        coffee.gameObject.SetActive(active);
    //}

    //public void ShowIceCream(object[] datas)
    //{
    //    if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
    //    CupType iceCream = cupTypes.Find(x => x.item_Type == Item_type.IceCream);
    //    if (iceCream != null)
    //        iceCream.gameObject.SetActive(active);
    //}
    //public void ShowLidCup(object[] datas)
    //{
    //    if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
    //    CupType lid = cupTypes.Find(x => x.item_Type == Item_type.Lid);
    //    if (lid != null)
    //        lid.gameObject.SetActive(active);
    //}
    //public void ShowIce7Color(object[] datas)
    //{
    //    if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
    //    CupType ice7 = cupTypes.Find(x => x.item_Type == Item_type.ice7Color);
    //    if (ice7 != null)
    //        ice7.gameObject.SetActive(active);
    //}
    //private void OnDestroy()
    //{
    //    Observer.RemoveObserver(ListAction.ShowCoffee, ShowCoffee);
    //    Observer.RemoveObserver(ListAction.ShowIceCream, ShowIceCream);
    //    Observer.RemoveObserver(ListAction.ShowLidCup, ShowLidCup);
    //    Observer.RemoveObserver(ListAction.ShowIce7, ShowIce7Color);
    //}
}
