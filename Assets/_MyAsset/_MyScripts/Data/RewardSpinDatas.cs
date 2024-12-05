//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Sirenix.OdinInspector;
//using UnityEngine.UI;

//[CreateAssetMenu(fileName = "RewardSpinDatas", menuName = "ScriptableObjects/RewardSpinDatas", order = 1)]
//public class RewardSpinDatas : ScriptableObject
//{
//    public List<RewardData> rewards;
//}

//[System.Serializable]
//public class RewardData
//{
//    [HorizontalGroup("Split", 75)]
//    [HideLabel]
//    [PreviewField(75)]
//    [VerticalGroup("Split/Left")]
//    public Image image;

//    [VerticalGroup("Split/Right")]
//    [LabelWidth(100)]
//    public string NameItem;

//    [VerticalGroup("Split/Right")]
//    [LabelWidth(100)]
//    public int idGift;

//    [VerticalGroup("Split/Right")]
//    [LabelWidth(100)]
//    public int moneyReward;
//}