using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMain : MonoBehaviour
{
    [SerializeField] private Text levelIndex;
    private int level;

    private void OnEnable()
    {
        level = GameControllManager.Ins.getlevel() + 1;
        levelIndex.text = level.ToString();
    }
}
