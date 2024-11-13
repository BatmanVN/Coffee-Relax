using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{

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
            StartCoroutine(show_win_panel());
            Debug.Log("Finish");
            Controller_Items.instance.move_all_to_center_finish_level();
            Observer.Notify(ListAction.FinishGame, Controller_Items.instance.total_items);
        }
    }
    IEnumerator show_win_panel()
    {
        yield return new WaitForSeconds(2f);

        UIManager.Ins.OpenUI<Win_UI>();

        //Advertisements.Instance.ShowInterstitial();
    }
}
