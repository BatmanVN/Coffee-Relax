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
            GameObject gm = Instantiate(money_stash, money_stash_pos.position, money_stash.transform.rotation);

            Destroy(gm, 2f);

            FabricaBox fb = Instantiate(fabrica_pref , path[0] , fabrica_pref.transform.rotation).GetComponent<FabricaBox>();


            CupGroup br = other.GetComponent<CupGroup>();
            if (br != null && fb != null)
            {
                if (br.coffee != null && br.coffee.gameObject.activeSelf)
                {
                    fb.coffe.SetActive(true);
                    br.coffee.SetActive(false);
                }

                if (br.iceCream != null && br.iceCream.gameObject.activeSelf)
                {
                    fb.iceCream.SetActive(true);
                    br.iceCream.SetActive(false);
                }


                if (br.lidCup != null && br.lidCup.gameObject.activeSelf)
                {
                    fb.lid.SetActive(true);
                    br.lidCup.SetActive(false);
                }

            }

            if (fb.coffe.gameObject.activeSelf)
                Observer.Notify(ListAction.IncreaseMoney, 50);
            if (fb.iceCream.gameObject.activeSelf)
                Observer.Notify(ListAction.IncreaseMoney, 100);
            if (fb.lid.gameObject.activeSelf)
                Observer.Notify(ListAction.IncreaseMoney, 50);

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
