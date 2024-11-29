using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseHammerTrap : MonoBehaviour
{
    [SerializeField] protected GameObject cupFB;
    [SerializeField] protected float hitForce;

    public int CupId_Use;

    public bool isImpact;

    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                cupFB = cupSpawn.buckSell;
            }
        }
    }

    protected virtual void ThrownOffCup(FabricaBox fb, Vector3 force ,Rigidbody rb)
    {
        rb = fb.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        rb.AddForce(force * hitForce, ForceMode.Impulse);

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
}