using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : UICanvas
{
    //public List<Button> buttons;
    [Header("SkinData")]
    public SkinCharacterData skinDatas;
    private void Awake()
    {

    }
    private void OnEnable()
    {
        Observer.Notify(UiAction.SpawnModel);
        if (BGMusic.instance != null)
        {
            BGMusic.PlayRandomSound(MusicType.MainMenu);
        }
    }
    private void Start()
    {
        BGMusic.PlayRandomSound(MusicType.MainMenu);
    }
}
