using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSpawn : MonoBehaviour
{
    [SerializeField] public List<Transform> spawnsTransform;
    [SerializeField] protected GameObject machinePrefab;
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
        for (int i = spawnsTransform.Count - 1; i >= 0; i--)
        {
            GameObject cup = Instantiate(machinePrefab, spawnsTransform[i].position, spawnsTransform[i].rotation);
            cup.transform.SetParent(spawnsTransform[i].gameObject.transform);
            spawnsTransform[i].gameObject.SetActive(true);
            spawnsTransform.RemoveAt(i);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnObject, SpawnMachine);
    }
}
