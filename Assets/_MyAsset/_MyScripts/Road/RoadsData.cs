using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoadsData", menuName = "ScriptableObjects/RoadsData", order = 1)]
public class RoadsData : ScriptableObject
{
    public List<RoadData> roads;
}
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

    [VerticalGroup("Split/Right")]
    [LabelWidth(100)]
    public GameObject roadInst;

}