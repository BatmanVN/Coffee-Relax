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
        //foreach (Transform button in transform)
        //{
        //    buttons.Add(button.GetComponent<Button>());
        //}
    }
    private void OnEnable()
    {
        Observer.Notify(UiAction.SpawnModel);
    }
    private void Start()
    {
        
    }
}
