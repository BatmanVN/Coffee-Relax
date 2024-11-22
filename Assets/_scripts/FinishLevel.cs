using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : Singleton<FinishLevel>
{
    private Coroutine showWin;
    private int currentMoney;
    private int moneyAfterWin;
    public int totalCoin;
    private void OnEnable()
    {
        currentMoney = GameControllManager.Ins.getcoin();
    }
    void Start()
    {

    }

    //When Finish
    private void OnTriggerEnter(Collider finish)
    {
        if (finish.CompareTag(Const.playerTag))
        {
            //active = false;

            //Observer.Notify(ListAction.FinishGame, true);
            showWin = StartCoroutine(show_win_panel());

            Observer.Notify(ListAction.FinishGame, Controller_Items.Ins.total_items);
            Observer.Notify(ListAction.EndRoad,true);
        }
        if (finish.CompareTag(Const.cupTag))
        {

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
                    if (cupType.money <= 0 || Controller_Items.Ins.count_items <= 0)
                    {
                        Observer.Notify(ListAction.DecreaseMoney, -50);
                        Debug.Log("decrese Money");
                    }
                }
            }
        }
    }


    IEnumerator show_win_panel()
    {
        yield return new WaitForSeconds(8f);

        UIManager.Ins.OpenUI<Win_UI>();
        UIManager.Ins.CloseUI<InGame_UI>();
        Observer.Notify(ListAction.FinishGame, Controller_Items.Ins.total_items);
        moneyAfterWin = GameControllManager.Ins.getcoin();
        totalCoin = moneyAfterWin - currentMoney;
        StopCoroutine(showWin);

        //Advertisements.Instance.ShowInterstitial();
    }
}
