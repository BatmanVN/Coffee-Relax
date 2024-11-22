using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModel_Main : MonoBehaviour
{
    public GameObject model;
    public int skinID;
    private float changeInterval = 3f;
    private string[] animationStates = { Const.idleAnim, Const.thinkAnim, Const.byeAnim, Const.cuteAnim, Const.walkModelAnim, Const.reiAnim, Const.flyIdleAnim };

    private Coroutine anim;

    private void OnEnable()
    {
        SpawnModel();
    }
    private void Start()
    {
        
    }
    public void SpawnModel(/*object[] datas*/)
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

    private IEnumerator ChangeAnimationRoutine()
    {
        while (true)
        {

            string randomAnimation = animationStates[Random.Range(0, animationStates.Length)];


            model.gameObject.GetComponent<Animator>().SetTrigger(randomAnimation);


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
