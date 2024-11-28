using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "LevelsDatas", menuName = "ScriptableObjects/LevelsDatas", order = 1)]
public class LevelsDatas : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = true)]
    public List<LevelData> levels;
}

[System.Serializable]
public class LevelData
{

    public int level;

    public GameObject levelPrefab;
}
