using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelRandomManager : Singleton<LevelRandomManager>
{
    //public List<GameObject> listLevel;
    public LevelsDatas levelsDatas;
    //public List<Transform> spawnLevels;
    public Transform spawnLevel;
    public int levelIndex;
    //public Transform finish;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.NextLevel, SelectLevel);
    }

    //private void Start()
    //{
    //    foreach (Transform child in transform)
    //    {
    //        spawnLevels.Add(child);
    //    }
    //}

    protected void SelectLevel(object[] datas)
    {
        levelIndex = GameControllManager.Ins.getlevel() + 1;
        int totalLevel = levelsDatas.levels.Count;
        if (levelIndex >= levelsDatas.levels.Count + 1)
        {
            levelIndex = Random.Range(1, levelsDatas.levels.Count + 1);
            Debug.Log("level > " + totalLevel);
        }
        else
        {
            if (levelIndex == levelsDatas.levels[levelIndex - 1].level)
            {
                levelIndex = GameControllManager.Ins.getlevel() + 1;
            }
            Debug.Log("level < " + totalLevel);
        }
        GameObject level = Instantiate(levelsDatas.levels[levelIndex - 1].levelPrefab, spawnLevel.transform.position, spawnLevel.transform.rotation);
        level.transform.SetParent(spawnLevel.transform);
        level.transform.localPosition = levelsDatas.levels[levelIndex - 1].levelPrefab.transform.position;

        Debug.Log("Level: " +  levelIndex);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.NextLevel, SelectLevel);
    }
}
