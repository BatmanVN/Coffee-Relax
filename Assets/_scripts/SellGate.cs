using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellGate: MonoBehaviour
{
    public GameObject fabrica_pref;
    public Transform[] positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    public Transform money_stash_pos;
    public GameObject money_stash;
    //public float moneyIncrease;

    // Start is called before the first frame update
    void Start()
    {
        convert_transform_to_vectors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //UiManager.instance._vibrate();
            Observer.Notify(ListAction.IncreaseMoney,50);
            //UiManager.instance.increase_money(50);
            GameObject gm = Instantiate(money_stash, money_stash_pos.position, money_stash.transform.rotation);

            Destroy(gm, 2f);

            FabricaBox fb = Instantiate(fabrica_pref , path[0] , fabrica_pref.transform.rotation).GetComponent<FabricaBox>();


            CupGroup br = other.GetComponent<CupGroup>();

            //if (br.has_mascara)
            //{
            //    fb.mascara.SetActive(true);
            //}
            //if (br.has_lipstick)
            //{
            //    fb.lipstick.SetActive(true);
            //}

            fb.transform.DOPath(path, duration, path_type, path_mode, 10, Color.red)
                .OnComplete(() => Destroy(fb.gameObject));

            Controller_Items.instance.decrease_item();
        }
    }

    void convert_transform_to_vectors()
    {
        path = new Vector3[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            path[i] = positions[i].position;
        }
    }
}
