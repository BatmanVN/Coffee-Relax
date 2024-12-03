using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevel : MonoBehaviour
{
    public Text txt_Level;
    private int level;
    protected void OnEnable()
    {
        level = GameControllManager.Ins.getlevel() + 1;
    }
    private void Start()
    {
        SetTextLevel();
    }
    public void SetTextLevel()
    {
        txt_Level.text = level.ToString();
    }
}
