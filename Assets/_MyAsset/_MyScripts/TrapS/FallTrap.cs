using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class FallTrap : MonoBehaviour
{
    [SerializeField] private GameObject cupIns;
    [SerializeField] private Transform pointFall;

    public int CupId_Use;
    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                cupIns = cupSpawn.buckInst;
            }
        }
    }

    private void OnTriggerEnter(Collider fall)
    {
        if (fall.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            Controller_Items.Ins.decrease_item();
            CupGroup cupObj = Instantiate(cupIns, pointFall.transform.position, pointFall.transform.rotation).gameObject.GetComponent<CupGroup>();
            Rigidbody rb = cupObj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
