using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeGift
{
    MoneyGift,
    CharacterGift,
    CupGift,
    LoseGift
}

public abstract class BaseGift : MonoBehaviour
{
    [field: SerializeField] public int moneyGift {  get; protected set; }
    public TypeGift typeGift;
    [field: SerializeField] public int prizeSegment { get; set; }

    public abstract void GetPrize();
}
