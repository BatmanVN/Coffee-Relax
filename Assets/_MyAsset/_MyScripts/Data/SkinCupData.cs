using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SkinCupData", menuName = "ScriptableObjects/SkinCupData", order = 1)]
public class SkinCupData : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<SkinCupItemData> skinDatas;
}

[System.Serializable]
public class SkinCupItemData
{
    [HorizontalGroup("Split", 75)]
    [HideLabel]
    [PreviewField(75)]
    [VerticalGroup("Split/Left")]
    public Sprite sprite;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int id;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public string NameCup;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject buckInst;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject buckMap;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject buckSell;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int price;
}