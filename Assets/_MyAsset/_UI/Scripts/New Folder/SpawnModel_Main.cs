using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnModel_Main : MonoBehaviour
{
    public GameObject model;
    public int skinID;
    private float changeInterval = 5f;

    public Button touchCharacter;
    public bool isTouch;
    public float timeTouch;

    private Coroutine anim;
    private Coroutine turnOff;
    private Coroutine voice;

    private void OnEnable()
    {
        SpawnModel();
    }
    private void Start()
    {
        touchCharacter.onClick?.AddListener(TouchPlayer);
        if (model != null)
        {
            model.GetComponent<Animator>().SetTrigger(ConstDanceAnim.byeAnim);
        }
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
                model.transform.localScale = new Vector3(0.045f, 0.045f, 0.045f);
                anim = StartCoroutine(ChangeAnimationRoutine());
            }
        }
    }

    private void TouchPlayer()
    {
        if (model == null) return;
        model.GetComponent<Animator>().SetTrigger(ConstDanceAnim.angryAnim);
        isTouch = true;
        SoundManager.PlayIntSound(SoundType.AnimeGirl, 4);
        turnOff = StartCoroutine(TurnOffTouch());
    }
    private IEnumerator TurnOffTouch()
    {
        yield return new WaitForSeconds(timeTouch);
        isTouch = false;
        anim = StartCoroutine(ChangeAnimationRoutine());
        StopCoroutine(turnOff);
    }
    private IEnumerator ChangeAnimationRoutine()
    {
        var modleAnim = model.GetComponent<Animator>();
        yield return new WaitForSeconds(changeInterval);

        while (!isTouch)
        {
            int randomAnim = Random.Range(0, ConstDanceAnim.DanceList.Count);
            string randomAnimation = ConstDanceAnim.DanceList[randomAnim];

            modleAnim.SetTrigger(randomAnimation);

            AnimatorStateInfo stateInfo = modleAnim.GetCurrentAnimatorStateInfo(0);
            while (stateInfo.IsName(randomAnimation) && stateInfo.normalizedTime < 1)
            {
                yield return null;
                stateInfo = modleAnim.GetCurrentAnimatorStateInfo(0);
            }
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
