using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTrap : BasePunchTrap
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);

            FabricaBox fb = Instantiate(fabrica_pref, path[0], fabrica_pref.transform.rotation).GetComponent<FabricaBox>();

            CupGroup br = other.GetComponent<CupGroup>();

            if (br != null && fb != null)
            {
                CupType cupInsType = br.cupTypes.Find(type => type != null && type.gameObject.activeSelf);
                if (cupInsType != null)
                {
                    GetGameObjectValue(cupInsType.item_Type, fb);
                }
            }
            fb.transform.DOPath(path, duration, path_type, path_mode, 10, Color.red)
                .OnComplete(() => Destroy(fb.gameObject));
            Controller_Items.Ins.decrease_item();
        }
    }
}
