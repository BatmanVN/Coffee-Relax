using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGiftDollar : MonoBehaviour
{
    public int moneyGift;
    [field: SerializeField] public int prizeSegment;

    protected virtual void GetPrize(int reward)
    {

    }
}
