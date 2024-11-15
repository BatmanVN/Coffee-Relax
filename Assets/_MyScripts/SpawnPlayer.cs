using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject character;
    public SkinCharacterData characterData;
    private int id;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SpawnPlayer, PlayerSpawn);
    }
    protected void PlayerSpawn(object[] datas)
    {
        for (int i = 0; i < ViewCharacter.Ins.baseSkins.Count; i++)
        {
            id = GameControllManager.Ins.GetPlayerByID();
            if (ViewCharacter.Ins.baseSkins[i].isUse)
            {
                character = Instantiate(characterData.skinDatas[i].character_pref, this.transform.position, this.transform.rotation);
                Observer.Notify(ListAction.SetAimmator, characterData.skinDatas[i].anim);
                character.transform.SetParent(this.transform);
                CamFollow camFollow = GameObject.FindGameObjectWithTag("Cam").GetComponent<CamFollow>();
                if (camFollow != null)
                    camFollow.target = character.transform;
            }
        }

    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnPlayer, PlayerSpawn);
    }
}
