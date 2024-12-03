using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownPlayer : BaseThrownTrap
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
        {
            if (!isThrowed)
            {
                SoundManager.PlayIntSound(SoundType.TrapsSound, 3);

                anim.SetTrigger(Const.throwTrapAnim);
                Observer.Notify(ListAction.Vibrate);

                Observer.Notify(ActionInGame.PlayerFly, path, duration, path_type, path_mode);
                isThrowed = true;
            }
            Debug.Log(other.gameObject.name);
        }
    }
}
