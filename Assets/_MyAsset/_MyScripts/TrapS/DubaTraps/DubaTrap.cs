using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubaTrap : MonoBehaviour
{
    public GameObject fabrica_pref;
    public Transform[] positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    //private bool isThrowed;
    public int CupId_Use;

    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData skinCup in GameControllManager.Ins.cupData.skinDatas)
        {
            if (skinCup.id == CupId_Use)
            {
                fabrica_pref = skinCup.buckSell;
            }
        }
    }

    private void Start()
    {
        convert_transform_to_vectors();
    }

    private void OnTriggerEnter(Collider storm)
    {
        if (storm.CompareTag(Const.cupTag))
        {
            FabricaBox fb = Instantiate(fabrica_pref, positions[0].position, positions[0].rotation).GetComponent<FabricaBox>();
            CupGroup cupIns = storm.GetComponent<CupGroup>();

            if (cupIns != null && fb != null)
            {
                CupType typeCup = cupIns.cupTypes.Find(type => type != null && type.gameObject.activeSelf);

                if (typeCup != null)
                    GetGameObjectValue(typeCup.item_Type, fb);
            }
            fb.transform.DOPath(path, duration, path_type, path_mode, 10, Color.red)
            .OnComplete(() => Destroy(fb.gameObject));
            //isThrowed = true;
            Controller_Items.Ins.decrease_item();
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
