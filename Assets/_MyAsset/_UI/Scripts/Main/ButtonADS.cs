using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonADS : MonoBehaviour
{
    [SerializeField] private Button adsButton;
    private void OnValidate()
    {
        adsButton = GetComponent<Button>();
    }
    private void Start()
    {
        adsButton.onClick?.AddListener(ShowADS);
    }

    private void ShowADS()
    {
        SoundManager.PlaySound(SoundType.ShowUpADS);
    }
}
