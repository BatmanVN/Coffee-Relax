using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiyotinObstacle : MonoBehaviour
{
    public GameObject smoke;
    public GameObject cupCrash;
    public int CupId_Use;
    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                cupCrash = cupSpawn.buckMap;
            }
        }
    }

    private void OnTriggerEnter(Collider cutter)
    {
        if (cutter.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            Controller_Items.Ins.decrease_item();
            GameObject slash = Instantiate(smoke, cutter.transform.position, cutter.transform.rotation);
            Destroy(slash, 1f);
            CupObject cupObj = Instantiate(cupCrash, cutter.transform.position, cutter.transform.rotation).gameObject.GetComponent<CupObject>();
            Rigidbody rb = cupObj.GetComponent<Rigidbody>();
            if (cupObj != null)
            {
                SoundManager.PlayIntSound(SoundType.TrapsSound, 0);
                rb.isKinematic = false;
                rb.AddForce(new Vector3(
                    Random.Range(-1.5f, 2f),// Lực ngẫu nhiên trên trục X
                    0, // Lực ngẫu nhiên trên trục Y (hướng lên)
                    Random.Range(2f, 3f)), // Lực ngẫu nhiên trên trục Z)
                    ForceMode.Impulse); 

                cupObj.GetComponent<Collider>().enabled = false;
                cupObj.anim.SetTrigger(Const.crashTrapAnim);
            }
            Destroy(cupObj.gameObject, 5f);
        }
    }
}
