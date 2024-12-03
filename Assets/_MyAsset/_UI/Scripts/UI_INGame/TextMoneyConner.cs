using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;

public class TextMoneyConner : MonoBehaviour
{
    public Text txt_mmoney;
    private Coroutine effect;

    protected void OnEnable()
    {
        Observer.AddObserver(ListAction.Vibrate, _vibrate);
        Observer.AddObserver(ListAction.IncreaseMoney, increase_money);
        Observer.AddObserver(ListAction.DecreaseMoney, Decrease_money);
        txt_mmoney.text = GameControllManager.Ins.getcoin().ToString();
    }
    public void increase_money(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int nbr)) return;
        GameControllManager.Ins.setcoin(GameControllManager.Ins.getcoin() + nbr);
        txt_mmoney.text = GameControllManager.Ins.getcoin().ToString();
        txt_mmoney.color = Color.yellow;
        effect = StartCoroutine(TurnOffEffect());
    }

    public void Decrease_money(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is int nbr)) return;
        GameControllManager.Ins.setcoin(GameControllManager.Ins.getcoin() + nbr);
        txt_mmoney.text = GameControllManager.Ins.getcoin().ToString();
        txt_mmoney.color = Color.red;
        if (GameControllManager.Ins.getcoin() < 0)
        {
            txt_mmoney.text = 0.ToString();
            GameControllManager.Ins.setcoin(0);
        }
        effect = StartCoroutine(TurnOffEffect());

    }


    public IEnumerator TurnOffEffect()
    {
        yield return new WaitForSeconds(0.1f);
        txt_mmoney.color = Color.white;
        StopCoroutine(effect);
    }

    protected  void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.Vibrate, _vibrate);
        Observer.RemoveObserver(ListAction.IncreaseMoney, increase_money);
        Observer.RemoveObserver(ListAction.DecreaseMoney, Decrease_money);
    }

    public void _vibrate(object[] datas)
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact, true, this);
    }
}
