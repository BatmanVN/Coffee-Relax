using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject character;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SpawnPlayer, PlayerSpawn);
    }
    protected void PlayerSpawn(object[] datas)
    {
        character = Instantiate(player , this.transform.position, this.transform.rotation);
        character.transform.SetParent(this.transform);
        CamFollow camFollow = GameObject.FindGameObjectWithTag("Cam").GetComponent<CamFollow>();
        if (camFollow != null )
            camFollow.target = character.transform;
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnPlayer, PlayerSpawn);
    }
}
