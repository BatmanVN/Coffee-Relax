using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : BaseRoadCut
{

    private void OnTriggerEnter(Collider fall)
    {
        if (fall.CompareTag(Const.cupTag))
        {
            HandleCupCollision(fall);
        }
    }



}
