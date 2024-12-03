using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownArrow : BaseThrownTrap
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
        {
            if (!isThrowed)
            {
                SoundManager.PlayIntSound(SoundType.TrapsSound,3);
                Observer.Notify(ListAction.Vibrate);

                Observer.Notify(ActionInGame.PlayerFly, path, duration, path_type, path_mode);
                isThrowed = true;
            }
            Debug.Log(other.gameObject.name);
        }
    }
}
