using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolTrap : MonoBehaviour
{
    public Animator anim;
    public GameObject fabrica_pref;
    public Transform[] positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    private bool isThrowed;
    public int CupId_Use;
    // Start is called before the first frame update
    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                fabrica_pref = cupSpawn.buckSell;
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
            //if (!isThrowed)
            //{
                //anim.SetTrigger(Const.throwTrapAnim);
                Observer.Notify(ListAction.Vibrate);

                FabricaBox fb = Instantiate(fabrica_pref, path[0], fabrica_pref.transform.rotation).GetComponent<FabricaBox>();

                CupGroup br = other.GetComponent<CupGroup>();

                if (br != null && fb != null)
                {
                    CupType cupInsType = br.cupTypes.Find(type => type != null && type.gameObject.activeSelf);
                    if (cupInsType != null)
                    {
                        GetGameObjectValue(cupInsType.item_Type, fb);
                    }
                }
                fb.transform.DOPath(path, duration, path_type, path_mode, 10, Color.red)
                    .OnComplete(() => Destroy(fb.gameObject));
                isThrowed = true;
                Controller_Items.Ins.decrease_item();
            //}
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
