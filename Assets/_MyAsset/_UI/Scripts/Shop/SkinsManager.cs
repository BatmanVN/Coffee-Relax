using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsManager : Singleton<SkinsManager>
{
    public List<BaseSkin> skinsStatus;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            skinsStatus.Add(child.GetComponent<BaseSkin>());
        }
    }
    public void StatusSkin()
    {
        foreach (BaseSkin skin in skinsStatus)
        {
            skin.used.SetActive(skin.isUse);
        }
    }
    private void Update()
    {
        StatusSkin();
    }
}
