using System;
using System.Collections.Generic;

[Serializable]
public class CharacterData
{
    public List<int> purchasedSkinIds;
    public int currentMoney;
    public int currentScore;


    public CharacterData()
    {
        purchasedSkinIds = new List<int> { 0 };
    }
}