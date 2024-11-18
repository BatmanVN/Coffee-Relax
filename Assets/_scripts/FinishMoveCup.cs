using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMoveCup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Controller_Items.Ins.move_all_to_center_finish_level();
            Observer.Notify(ListAction.FinishMove);
        }
    }
}
