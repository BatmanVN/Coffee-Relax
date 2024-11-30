using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTraps : BaseHammerTrap
{
    [SerializeField] private float timeCount = 0f;
    private Coroutine impact;

    private void OnTriggerEnter(Collider hammer)
    {
        if (hammer.CompareTag(Const.cupTag))
        {
            if (!isImpact)
            {
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
                ThrownOffCup(fb, forceDirection,fb.GetComponent<Rigidbody>());
                impact = StartCoroutine(CatchImpactAgain());
            }
        }
        if (hammer.CompareTag(Const.playerTag))
        {
            Observer.Notify(ListAction.Vibrate);
            Observer.Notify(ActionInGame.PushBack, 15f);
            isImpact = false;
        }
    }

    private IEnumerator CatchImpactAgain()
    {
        while (timeCount <= 10f)
        {
            timeCount += Time.deltaTime;
            yield return new WaitForSeconds(1f);
            isImpact = false;
        }
        StopCoroutine(impact);
    }
}
