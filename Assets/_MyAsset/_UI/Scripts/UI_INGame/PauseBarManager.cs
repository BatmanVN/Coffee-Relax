using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBarManager : MonoBehaviour
{
    protected List<PauseBarManager> pauseButtons;
    public PauseBarManager barManager;
    private void OnValidate()
    {
        barManager = GetComponent<PauseBarManager>();
    }
}
