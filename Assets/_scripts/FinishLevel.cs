using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private Coroutine showWin;
    public GameObject confet_Pref;
    //public Transform confetSpawn;
    //public GameObject confe;
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

            Observer.Notify(ListAction.FinishGame, Controller_Items.Ins.total_items);
            Observer.Notify(ListAction.EndRoad,true);
        }
        if (finish.CompareTag(Const.cupTag))
        {
            confet_Pref.SetActive(true);
            CupGroup br = finish.GetComponent<CupGroup>();
            if (br != null)
            {
                br.gameObject.SetActive(false);
                CupType cupType = br.cupTypes.Find(type => type != null && type.gameObject.activeSelf);
                if (cupType != null)
                {
                    if (cupType.money > 0)
                    {
                        Controller_Items.Ins.total_items++;
                        Observer.Notify(ListAction.IncreaseMoney, cupType.money);
                    }
                }
            }
        }
    }

    IEnumerator show_win_panel()
    {
        yield return new WaitForSeconds(3f);

        UIManager.Ins.OpenUI<Win_UI>();
        Observer.Notify(ListAction.FinishGame, Controller_Items.Ins.total_items);
        Destroy(confet_Pref);
        StopCoroutine(showWin);

        //Advertisements.Instance.ShowInterstitial();
    }
}
