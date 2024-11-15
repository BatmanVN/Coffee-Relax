using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSpawn : MonoBehaviour
{
    [SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected GameObject machinePrefab;
    public int randomSpawn;
    public int spawnCount;
    private void Awake()
    {
        foreach (Transform cupSpawn in transform)
        {
            spawnsTransform.Add(cupSpawn);
        }
    }
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SpawnObject, SpawnMachine);
    }
    private void Start()
    {

    }
    public void SpawnMachine(object[] datas)
    {
        for (int i = spawnsTransform.Count - 1; i >= spawnCount; i--)
        {
            randomSpawn = Random.Range(0, spawnsTransform.Count);
            GameObject cup = Instantiate(machinePrefab, spawnsTransform[randomSpawn].position, spawnsTransform[randomSpawn].rotation);
            cup.transform.SetParent(spawnsTransform[randomSpawn].gameObject.transform);
            spawnsTransform[randomSpawn].gameObject.SetActive(true);
            spawnsTransform.RemoveAt(randomSpawn);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnObject, SpawnMachine);
    }
}
