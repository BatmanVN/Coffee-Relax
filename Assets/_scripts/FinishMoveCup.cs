using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FinishMoveCup : MonoBehaviour
{
    public GameObject confet_Pref;
    [SerializeField] private GameObject bonus;
    private bool isFinish;
    //private Coroutine music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag) || other.CompareTag(Const.playerTag))
        {
            GameControllManager.Ins.bgMusic.Pause();
            confet_Pref.SetActive(true);
            bonus.SetActive(true);
            Observer.Notify(ListAction.FinishMove);
            //music = StartCoroutine(MusicOn());
        }
    }

    //private IEnumerator MusicOn()
    //{
    //    yield return new WaitForSeconds(1);
    //    SoundManager.PlaySound(SoundType.ClapCheer);
    //    StopCoroutine(music);
    //}
}
