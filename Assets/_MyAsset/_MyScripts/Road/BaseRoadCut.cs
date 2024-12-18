using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRoadCut : MonoBehaviour
{
    [field: SerializeField] protected GameObject cupIns { get; set; }
    [field: SerializeField] protected Transform pointFall { get; set; }

    public int CupId_Use;
    protected virtual void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                cupIns = cupSpawn.buckSell;
            }
        }
    }

    protected virtual void HandleCupType(CupGroup cupOnHand, FabricaBox fb)
    {
        CupType cupInsType = cupOnHand.cupTypes.Find(type => type != null && type.gameObject.activeSelf);
        if (cupInsType != null)
        {
            GetGameObjectValue(cupInsType.item_Type, fb);
        }
    }

    protected virtual void ApplyPhysicsToBox(FabricaBox fb)
    {
        Rigidbody rb = fb.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Destroy(fb.gameObject, 3f);
    }

    protected virtual void GetGameObjectValue(Item_type cupType, FabricaBox fb)
    {
        if (fb != null && fb.cupTypes != null)
        {
            CupType typeFb = fb.cupTypes.Find(cupfb => cupfb.item_Type == cupType);
            if (typeFb != null)
                typeFb.gameObject.SetActive(true);
        }
    }

    protected virtual void HandleCupCollision(Collider fall)
    {
        Observer.Notify(ListAction.Vibrate);
        Controller_Items.Ins.decrease_item();

        FabricaBox fb = Instantiate(cupIns, pointFall.transform.position, pointFall.transform.rotation).gameObject.GetComponent<FabricaBox>();
        CupGroup cupOnHand = fall.GetComponent<CupGroup>();

        if (fb != null && cupOnHand != null)
        {
            HandleCupType(cupOnHand, fb);
        }
        ApplyPhysicsToBox(fb);
    }
}
