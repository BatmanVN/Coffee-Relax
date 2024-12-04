using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseHammerTrap : MonoBehaviour
{
    [SerializeField] protected GameObject cupFB;
    [SerializeField] protected float hitForce;
    protected Coroutine impact;
    protected bool playerImpact;
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

    protected virtual void HandleCupImpact(Collider hammer)
    {
        if (!isImpact)
        {
            SoundManager.PlayIntSound(SoundType.TrapsSound, 8);

            isImpact = true;
            Observer.Notify(ListAction.Vibrate);
            Controller_Items.Ins.decrease_item();
            FabricaBox fb = Instantiate(cupFB, hammer.transform.position, hammer.transform.rotation).GetComponent<FabricaBox>();
            CupGroup cupIns = hammer.GetComponent<CupGroup>();
            if (cupIns != null)
            {
                CupType cupType = cupIns.cupTypes.Find(type => type != null && type.gameObject.activeSelf);
                if (cupType != null)
                {
                    GetGameObjectValue(cupType.item_Type, fb);
                }
            }

            Vector3 forceDirection = (hammer.transform.position - transform.position).normalized;
            ThrownOffCup(fb, forceDirection, fb.GetComponent<Rigidbody>());
        }
    }

    protected virtual void HandlePlayerImpact()
    {
        if (!playerImpact)
        {
            Observer.Notify(ListAction.Vibrate);
            Observer.Notify(ActionInGame.PushBack, 8f);
            isImpact = false;
            playerImpact = true;
            SoundManager.PlayIntSound(SoundType.GirlVoiceE, 5);
        }
    }

}