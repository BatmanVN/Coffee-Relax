using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBonus : MonoBehaviour
{
    public Button bonusMoney;

    private void Start()
    {
        bonusMoney.onClick?.AddListener(BonusButton);
    }
    private void BonusButton()
    {
        SoundManager.PlaySound(SoundType.ClickButton);
    }
}
