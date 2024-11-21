using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CupGroup : MonoBehaviour
{
    Sequence sequence;
    public Ease ease_bounce, ease_linear;
    public float time;
    public List<CupType> cupTypes;
    public Item_type item_Type;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SetUpCupTypes, SetActiveObjects);
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
    public void SetActiveObjects(object[] datas)
    {
        foreach (CupType cupType in cupTypes)
        {
            cupType.gameObject.SetActive(item_Type == cupType.item_Type);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SetUpCupTypes,SetActiveObjects);
    }
}
