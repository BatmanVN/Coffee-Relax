using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCutRoad : BaseRoadCut
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            HandleCupCollision(other);
        }
    }
    protected override void HandleCupCollision(Collider fall)
    {
        base.HandleCupCollision(fall);
        pointFall = fall.transform;
    }
}
