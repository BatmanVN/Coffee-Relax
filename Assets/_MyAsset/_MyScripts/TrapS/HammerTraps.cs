using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTraps : BaseHammerTrap
{
    [SerializeField] private float timeCount = 0f;


    private void OnTriggerEnter(Collider hammer)
    {
        if (hammer.CompareTag(Const.cupTag))
        {
            HandleCupImpact(hammer);
            if (!isImpact)
            {
                impact = StartCoroutine(CatchImpactAgain());
            }
        }
        if (hammer.CompareTag(Const.playerTag))
        {
            HandlePlayerImpact();
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
