using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellGate: MonoBehaviour
{
    public GameObject fabrica_pref;
    public Transform[] positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    public Transform money_stash_pos;
    public GameObject money_stash;
    public int cupId;

    private void OnEnable()
    {
        cupId = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cup in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cup.id == cupId)
            {
                fabrica_pref = cup.buckSell;
            }
        }
    }

    void Start()
    {
        convert_transform_to_vectors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //GameObject gm = Instantiate(money_stash, money_stash_pos.position, money_stash.transform.rotation);

            //Destroy(gm, 2f);

            CupGroup br = other.GetComponent<CupGroup>();
            if(br.item_Type == Item_type.Cup) return;
            FabricaBox fb = Instantiate(fabrica_pref , path[0] , fabrica_pref.transform.rotation).GetComponent<FabricaBox>();


            if (br != null && fb != null)
            {
                CupType cupInsType = br.cupTypes.Find(type => type != null && type.gameObject.activeSelf && type.item_Type != Item_type.Cup);
                if (cupInsType != null)
                {
                    GetGameObjectValue(cupInsType.item_Type, fb);
                    if (cupInsType.money > 0)
                    {
                        Controller_Items.Ins.total_items++;
                        Observer.Notify(ListAction.IncreaseMoney, cupInsType.money);
                    }
                    cupInsType.gameObject.SetActive(false);
                }
            }
            fb.transform.DOPath(path, duration, path_type, path_mode, 10, Color.red)
                .OnComplete(() => Destroy(fb.gameObject));

            Controller_Items.Ins.decrease_item();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            CupGroup br = other.GetComponent<CupGroup>();
            br.item_Type = Item_type.Cup;
        }
    }
    private void GetGameObjectValue(Item_type cupType, FabricaBox fb)
    {
        if (fb != null && fb.cupTypes != null)
        {
            CupType typeFb = fb.cupTypes.Find(cupfb => cupfb.item_Type == cupType);
            if (typeFb != null)
                typeFb.gameObject.SetActive(true);
        }
    }
    void convert_transform_to_vectors()
    {
        path = new Vector3[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            path[i] = new Vector3(positions[i].position.x, positions[i].position.y, positions[i].position.z + 0.5f);
        }
    }
}
