using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpawnManager : MonoBehaviour
{
    [SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected GameObject cupPrefab;
    public int CupId_Use;
    private void Awake()
    {
        foreach (Transform cupSpawn in transform)
        {
            spawnsTransform.Add(cupSpawn);
        }
    }
    private void OnEnable()
    {
        CupId_Use = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cupSpawn in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cupSpawn.id == CupId_Use)
            {
                cupPrefab = cupSpawn.buckMap;
            }
        }
        Observer.AddObserver(ListAction.SpawnObject, SpawnCups);
    }
    private void Start()
    {

    }
    public void SpawnCups(object[] datas)
    {
        for (int i = spawnsTransform.Count - 1; i >= 0; i--)
        {
            GameObject cup = Instantiate(cupPrefab, spawnsTransform[i].position, spawnsTransform[i].rotation);
            cup.transform.SetParent(spawnsTransform[i].gameObject.transform);
            spawnsTransform[i].gameObject.SetActive(true);
            spawnsTransform.RemoveAt(i);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnObject, SpawnCups);
    }
}
