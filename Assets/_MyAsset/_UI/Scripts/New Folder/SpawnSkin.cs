using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkin : MonoBehaviour
{
    [SerializeField] private ButtonPlayerShop buttonPlayer;
    private void OnValidate()
    {
        buttonPlayer = GetComponent<ButtonPlayerShop>();
    }
    public void SpawnCharacter()
    {
        buttonPlayer.spawnRect.anchoredPosition = new Vector3(0, 1.4f);
        buttonPlayer.spawnRect.localPosition = new Vector3(buttonPlayer.spawnRect.localPosition.x, buttonPlayer.spawnRect.localPosition.y, -1098f);
    }
    public void SpawnCup()
    {
        buttonPlayer.spawnRect.anchoredPosition = new Vector3(0, 0.8f);
        buttonPlayer.spawnRect.localPosition = new Vector3(buttonPlayer.spawnRect.localPosition.x, buttonPlayer.spawnRect.localPosition.y, -1095f); // Thay đổi Z
    }
}
