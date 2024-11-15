using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject character;
    public SkinCharacterData characterData;
    public int skinID;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SpawnPlayer, PlayerSpawn);
    }
    private void Start()
    {
        
    }
    public void PlayerSpawn(object[] datas)
    {
        var listSkinDatas = GameControllManager.Ins.characterData.skinDatas;
        for (int i = 0; i < listSkinDatas.Count; i++)
        {
            if (GameControllManager.Ins.GetStatusUseSkin(listSkinDatas[i].NameCharacter))
            {
                skinID = i;
                character = Instantiate(listSkinDatas[skinID].character_pref, transform.position, transform.rotation);
                character.transform.SetParent(transform);
                Observer.Notify(ListAction.SetCamFollow, character.transform);
                Observer.Notify(ListAction.SetAimmator,character.GetComponent<Animator>());
            }
        }
    }
    private void DestroyModel(object[] datas)
    {
        if (character != null)
            Destroy(character);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.DestroyModel, DestroyModel);
        Observer.RemoveObserver(ListAction.SpawnPlayer, PlayerSpawn);
    }
}
