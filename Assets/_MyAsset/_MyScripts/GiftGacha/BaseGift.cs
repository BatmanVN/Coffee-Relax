using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGift : MonoBehaviour
{
    public int moneyGift;
    [field: SerializeField] public int prizeSegment { get; set; }

    public abstract void GetPrize();
}
