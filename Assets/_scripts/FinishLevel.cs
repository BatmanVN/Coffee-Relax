using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private Coroutine showWin;
    public GameObject confet_Pref;
    public Transform confetSpawn;
    public GameObject confe;
    void Start()
    {
        
    }

    //When Finish
    private void OnTriggerEnter(Collider finish)
    {
        if (finish.CompareTag(Const.playerTag))
        {
            //active = false;

            Observer.Notify(ListAction.FinishGame, true);
            showWin = StartCoroutine(show_win_panel());

            Controller_Items.instance.move_all_to_center_finish_level();
            Observer.Notify(ListAction.FinishGame, Controller_Items.instance.total_items);
        }
        if (finish.CompareTag(Const.cupTag))
        {
            confe = Instantiate(confet_Pref, confetSpawn.position, confetSpawn.rotation);
            confe.transform.SetParent(confetSpawn.transform);
            CupGroup br = finish.GetComponent<CupGroup>();
            if (br != null)
            {
                br.gameObject.SetActive(false);
                if (br.coffee.gameObject.activeSelf)
                    Observer.Notify(ListAction.IncreaseMoney, 50);
                if (br.iceCream.gameObject.activeSelf)
                    Observer.Notify(ListAction.IncreaseMoney, 100);
                if (br.lidCup.gameObject.activeSelf)
                    Observer.Notify(ListAction.IncreaseMoney, 50);
            }
        }
    }
    IEnumerator show_win_panel()
    {
        yield return new WaitForSeconds(3f);

        UIManager.Ins.OpenUI<Win_UI>();

        Destroy(confe);
        StopCoroutine(showWin);
        //Advertisements.Instance.ShowInterstitial();
    }
}
