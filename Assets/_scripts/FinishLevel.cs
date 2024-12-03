using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : Singleton<FinishLevel>
{
    [SerializeField] private GameObject bonusMoney;
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
                        SoundManager.PlaySound(SoundType.TakeMoney);
                        Controller_Items.Ins.total_items++;
                        Observer.Notify(ListAction.IncreaseMoney, cupType.money);
                        Debug.Log(GameControllManager.Ins.getcoin());
                    }
                    if(cupType.money < 0)
                    {
                        if (GameControllManager.Ins.getcoin() <= 0) return;
                        Observer.Notify(ListAction.DecreaseMoney, cupType.money);
                        Debug.Log(cupType.money);
                        SoundManager.PlaySound(SoundType.DecreaseCup);
                    }
                }
            }
        }
    }

    IEnumerator show_win_panel()
    {
        yield return new WaitForSeconds(15f);
        bonusMoney.SetActive(false);
        UIManager.Ins.OpenUI<Win_UI>();
        UIManager.Ins.CloseUI<InGame_UI>();
        if (Controller_Items.Ins != null)
        {
            Observer.Notify(ListAction.FinishGame, Controller_Items.Ins.total_items);
            if (Controller_Items.Ins.total_items > 0)
            {
                SoundManager.PlayIntSound(SoundType.WinUiSound, 0);
            }
            else
                SoundManager.PlayIntSound(SoundType.WinUiSound, 1);
        }
        else
        {
            Debug.LogError("Controller_Items.Ins is null!");
        }

        moneyAfterWin = GameControllManager.Ins.getcoin();
        totalCoin = moneyAfterWin - currentMoney;

        //Advertisements.Instance.ShowInterstitial();
    }
}
