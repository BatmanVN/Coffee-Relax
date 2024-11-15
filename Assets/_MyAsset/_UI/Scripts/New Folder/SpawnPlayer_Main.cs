using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer_Main : MonoBehaviour
{
    public GameObject model;
    public int skinID;
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.DestroyModel, DestroyModel);
        Observer.AddObserver(UiAction.SpawnModel, SpawnModel);
    }
    private void Start()
    {
        //SpawnModel();
    }
    public void SpawnModel(object[] datas)
    {
        var listSkinDatas = GameControllManager.Ins.characterData.skinDatas;
        for (int i = 0; i < listSkinDatas.Count; i++)
        {
            if (GameControllManager.Ins.GetStatusUseSkin(listSkinDatas[i].NameCharacter))
            {
                skinID = i;
                model = Instantiate(listSkinDatas[skinID].character_pref, transform.position, transform.rotation);
                model.transform.SetParent(transform);
            }
        }
    }
    private void DestroyModel(object[] datas)
    {
        if(model != null)
            Destroy(model);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.DestroyModel, DestroyModel);
        Observer.RemoveObserver(UiAction.SpawnModel, SpawnModel);
    }
}
