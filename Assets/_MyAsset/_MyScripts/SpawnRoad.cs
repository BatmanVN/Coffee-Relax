using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public GameObject roadPref;
    private GameObject currentRoad;
    private int level;
    private void OnEnable()
    {
        level = GameControllManager.Ins.getlevel();
        Observer.AddObserver(ActionInGame.SpawnRoad, RoadSpawn);
        Observer.AddObserver(ActionInGame.DisableRoad, DisableRoad);
    }
    protected void RoadSpawn(object[] datas)
    {
        if (roadPref != null)
        {
            currentRoad = Instantiate(roadPref, this.transform.position, this.transform.rotation);
            currentRoad.transform.SetParent(this.transform);
        }
        if(level > 10)
            this.enabled = false;
    }
    
    protected void DisableRoad(object[] datas)
    {
        if(currentRoad != null)
            this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        Destroy(currentRoad);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ActionInGame.SpawnRoad, RoadSpawn);
        Observer.RemoveObserver(ActionInGame.DisableRoad, DisableRoad);
    }
}
