using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkyBoxDatas", menuName = "ScriptableObjects/SkyBoxDatas", order = 1)]
public class SkyBoxDatas : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<SkyBox> skies;
}

[System.Serializable]
public class SkyBox
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
    public Material material;

}
