using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpawnManager : MonoBehaviour
{
    [SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected GameObject cupPrefab;
    public int randomSpawn;
    private void Awake()
    {
        foreach (Transform cupSpawn in transform)
        {
            spawnsTransform.Add(cupSpawn);
        }
    }
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SpawnObject, SpawnCups);
    }
    private void Start()
    {

    }
    public void SpawnCups(object[] datas)
    {
        for (int i = spawnsTransform.Count - 1; i >= 10; i--)
        {
            randomSpawn = Random.Range(0, spawnsTransform.Count);
            GameObject cup = Instantiate(cupPrefab, spawnsTransform[randomSpawn].position, spawnsTransform[randomSpawn].rotation);
            cup.transform.SetParent(spawnsTransform[randomSpawn].gameObject.transform);
            spawnsTransform[randomSpawn].gameObject.SetActive(true);
            spawnsTransform.RemoveAt(randomSpawn);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnObject, SpawnCups);
    }
}
