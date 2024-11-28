using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTraps : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private GameObject blockEffect;
    private void OnTriggerEnter(Collider block)
    {
        if (block.CompareTag(Const.cupTag) || block.CompareTag(Const.playerTag))
        {
            blockEffect.SetActive(true);
            Observer.Notify(ActionInGame.PushBack,distance);
            Controller_Items.Ins.decrease_item();
        }
    }
}
