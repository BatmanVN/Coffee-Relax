using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : Singleton<GiftManager>
{
    [field: SerializeField] public List<BaseGift> gifts { get; private set; }

    private void OnEnable()
    {
        foreach (Transform gift in transform)
        {
            gifts.Add(gift.GetComponent<BaseGift>());
        }
    }
}
