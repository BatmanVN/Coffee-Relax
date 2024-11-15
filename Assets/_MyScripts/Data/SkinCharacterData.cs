using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SkinCharacterData", menuName = "ScriptableObjects/SkinCharacterData", order = 1)]
public class SkinCharacterData : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<SkinCharacterItemData> skinDatas;
}

[System.Serializable]
public class SkinCharacterItemData
{
    [HorizontalGroup("Split", 75)]
    [HideLabel]
    [PreviewField(75)]
    [VerticalGroup("Split/Left")]
    public Sprite sprite;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public string NameCharacter;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int id;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject character_pref;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public int price;

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public Animator anim;
}
