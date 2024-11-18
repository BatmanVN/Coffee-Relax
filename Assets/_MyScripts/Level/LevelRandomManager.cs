using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelRandomManager : Singleton<LevelRandomManager>
{
    public List<GameObject> listLevel;
    public List<Transform> spawnLevels;
    public int levelIndex;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.NextLevel, SelectLevel);
        listLevel = Resources.LoadAll<GameObject>("Levels").ToList();
        //listLevel.AddRange(levels);
        // Sắp xếp danh sách theo số thứ tự trong tên
        listLevel = listLevel.OrderBy(level =>
        {
            // Lấy phần số từ tên đối tượng, giả sử tên có dạng "level_x"
            string name = level.name;
            string numberPart = name.Substring(name.LastIndexOf('_') + 1);

            // Chuyển đổi phần số thành int để sắp xếp chính xác
            return int.Parse(numberPart);
        }).ToList();

    }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            spawnLevels.Add(child);
        }
    }
    protected void SelectLevel(object[] datas)
    {
        levelIndex = GameControllManager.Ins.getlevel() + 1;
        if (levelIndex >= listLevel.Count + 1)
        {
            levelIndex = Random.Range(1, listLevel.Count + 1);
            Debug.Log("level > 10");
        }
        else
        {
            levelIndex = GameControllManager.Ins.getlevel() + 1;
            Debug.Log("level < 10");
        }
        GameObject level = Instantiate(listLevel[levelIndex - 1], spawnLevels[levelIndex - 1].transform.position, spawnLevels[levelIndex - 1].transform.rotation);
        level.transform.SetParent(spawnLevels[levelIndex - 1].transform);
        Debug.Log("Level: " +  levelIndex);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.NextLevel, SelectLevel);
    }
}
