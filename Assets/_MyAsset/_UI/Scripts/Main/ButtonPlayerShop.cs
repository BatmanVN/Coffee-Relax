using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPlayerShop : MonoBehaviour
{
    public ViewCharacter player;
    public Animator spawnPoint;
    private float changeInterval = 5f;
    private string[] animationStates = { Const.idleAnim, ConstDanceAnim.thinkAnim, ConstDanceAnim.byeAnim, ConstDanceAnim.cuteAnim, Const.walkModelAnim, ConstDanceAnim.reiAnim};
    public RectTransform spawnRect;
    //public float timeTouch;

    public bool isTouch;
    private Coroutine anim;

    private void OnValidate()
    {
        spawnRect = GetComponent<RectTransform>();
        spawnPoint = GetComponent<Animator>();
    }

    private void Start()
    {
        anim = StartCoroutine(ChangeAnimationRoutine());
    }

    private IEnumerator ChangeAnimationRoutine()
    {
        if (player.currentSkin == null) yield break;

        player.currentSkin.GetComponent<Animator>().SetTrigger(ConstDanceAnim.byeAnim);
        yield return new WaitForSeconds(changeInterval);
        while (true)
        {
            if (isTouch)
            {
                yield return new WaitForSeconds(2f);
                continue;
            }
            if (!isTouch)
            {
                string randomAnimation = animationStates[Random.Range(0, animationStates.Length)];
                if (player.currentSkin != null)
                {
                    player.currentSkin.GetComponent<Animator>().SetTrigger(randomAnimation);
                }
                yield return new WaitForSeconds(changeInterval);
            }

        }
    }
    private void OnDisable()
    {
        if (anim != null)
        {
            StopCoroutine(anim);
            anim = null;
        }
    }
}
