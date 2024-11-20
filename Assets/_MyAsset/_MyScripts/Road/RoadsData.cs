using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "RoadsData", menuName = "ScriptableObjects/RoadsData", order = 1)]
public class RoadsData : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<RoadData> roads;
}

[System.Serializable]
public class RoadData
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