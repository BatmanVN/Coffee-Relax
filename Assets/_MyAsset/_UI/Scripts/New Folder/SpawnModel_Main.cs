using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnModel_Main : MonoBehaviour
{
    public GameObject model;
    public int skinID;
    private float changeInterval = 3f;
    private string[] animationStates = { Const.idleAnim, Const.thinkAnim, Const.byeAnim, Const.cuteAnim, Const.walkModelAnim, Const.reiAnim, Const.flyIdleAnim };

    public Button touchCharacter;
    public bool isTouch;
    public float timeTouch;

    private Coroutine anim;
    private Coroutine turnOff;
    private void OnEnable()
    {
        SpawnModel();
    }
    private void Start()
    {
        touchCharacter.onClick?.AddListener(TouchPlayer);
    }
    public void SpawnModel()
    {
        var listSkinDatas = GameControllManager.Ins.characterData.skinDatas;
        skinID = GameControllManager.Ins.GetIDSkinUse();
        for (int i = 0; i < listSkinDatas.Count; i++)
        {
            if (listSkinDatas[i].id == skinID)
            {
                model = Instantiate(listSkinDatas[skinID].character_pref, transform.position, transform.rotation);
                model.transform.SetParent(transform);
                anim = StartCoroutine(ChangeAnimationRoutine());
            }
        }
    }

    private void TouchPlayer()
    {
        if (model == null) return;
        model.GetComponent<Animator>().SetTrigger(Const.angryAnim);
        isTouch = true;
        turnOff = StartCoroutine(TurnOffTouch());
    }
    IEnumerator TurnOffTouch()
    {
        yield return new WaitForSeconds(timeTouch);
        isTouch = false;
        anim = StartCoroutine(ChangeAnimationRoutine());
        StopCoroutine(turnOff);
    }

    private IEnumerator ChangeAnimationRoutine()
    {
        while (!isTouch)
        {
            string randomAnimation = animationStates[Random.Range(0, animationStates.Length)];
            model.GetComponent<Animator>().SetTrigger(randomAnimation);
            yield return new WaitForSeconds(changeInterval);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(anim);
        if(model != null)
            Destroy(model);
    }
    private void OnDestroy()
    {

    }
}
