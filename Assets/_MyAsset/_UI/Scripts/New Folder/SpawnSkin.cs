using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkin : MonoBehaviour
{
    public RectTransform spawn;

    private void Awake()
    {

    }
    public void SpawnCharacter()
    {
        spawn.anchoredPosition = new Vector3(0, 1.4f);
        spawn.localPosition = new Vector3(spawn.localPosition.x, spawn.localPosition.y, -1098f);
    }
    public void SpawnCup()
    {
        spawn.anchoredPosition = new Vector3(0, 0.8f);
        spawn.localPosition = new Vector3(spawn.localPosition.x, spawn.localPosition.y, -1095f); // Thay đổi Z
    }
}
