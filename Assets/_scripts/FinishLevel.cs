using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : Singleton<FinishLevel>
{
    [SerializeField] private GameObject bonusMoney;
    [SerializeField] private GameObject dollarBlastPre;
    [SerializeField] private GameObject dislikePre;
    [SerializeField] private Transform dollarTrans;
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

            showWin = StartCoroutine(show_win_panel());

            Observer.Notify(ListAction.FinishGame);
            MoneyTower.inst.moneyEffects.SetActive(true);
        }
        if (finish.CompareTag(Const.cupTag))
        {
            CupGroup br = finish.GetComponent<CupGroup>();
            if (br != null)
            {
                br.gameObject.SetActive(false);
                CheckCupType(br);
                if (br.item_Type == Item_type.Cup)
                {
                    Observer.Notify(ListAction.DecreaseMoney, -50);
                    SoundManager.PlaySound(SoundType.DecreaseCup);
                    GameObject dislike = Instantiate(dislikePre, dollarTrans.position, dollarTrans.rotation);
                    dislike.transform.SetParent(dollarTrans);
                    Destroy(dislike, 0.1f);
                }
            }
        }
    }

    private void CheckCupType(CupGroup br)
    {
        CupType cupType = br.cupTypes.Find(type => type != null && type.gameObject.activeSelf);
        if (cupType != null)
        {
            if (cupType.money > 0)
            {
                SoundManager.PlaySound(SoundType.TakeMoney);
                Controller_Items.Ins.total_items++;
                Observer.Notify(ListAction.IncreaseMoney, cupType.money);
                GameObject dollarEffect = Instantiate(dollarBlastPre, dollarTrans.position, dollarTrans.rotation);
                dollarEffect.transform.SetParent(dollarTrans);
                Destroy(dollarEffect, 0.1f);
            }
            if (cupType.money <= 0)
            {
                Observer.Notify(ListAction.DecreaseMoney, cupType.money);
                Debug.Log(cupType.money);
                SoundManager.PlaySound(SoundType.DecreaseCup);
                GameObject dislike = Instantiate(dislikePre, dollarTrans.position, dollarTrans.rotation);
                dislike.transform.SetParent(dollarTrans);
                Destroy(dislike, 0.1f);
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
