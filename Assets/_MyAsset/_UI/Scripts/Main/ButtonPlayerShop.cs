using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlayerShop : MonoBehaviour
{
    public Button touchCharacter;
    public ViewCharacter player;
    public Animator spawnPoint;
    private float changeInterval = 5f;
    private string[] animationStates = { Const.idleAnim, ConstDanceAnim.thinkAnim, ConstDanceAnim.byeAnim, ConstDanceAnim.cuteAnim, Const.walkModelAnim, ConstDanceAnim.reiAnim, Const.flyIdleAnim };
    public RectTransform spawnRect;
    public float timeTouch;

    public bool isTouch;

    private Coroutine turnOff;
    private Coroutine anim;

    private void OnEnable()
    {
        spawnRect = GetComponent<RectTransform>();
    }
    private void Start()
    {
        anim = StartCoroutine(ChangeAnimationRoutine());
        touchCharacter.onClick?.AddListener(TouchPlayer);
    }
    private IEnumerator ChangeAnimationRoutine()
    {
        player.currentSkin.GetComponent<Animator>().SetTrigger(ConstDanceAnim.byeAnim);
        yield return new WaitForSeconds(changeInterval);
        while (!isTouch)
        {
            string randomAnimation = animationStates[Random.Range(0, animationStates.Length)];
            if (player.currentSkin != null)
            {
                player.currentSkin.GetComponent<Animator>().SetTrigger(randomAnimation);
            }
            yield return new WaitForSeconds(changeInterval);
        }
    }

    private void TouchPlayer()
    {
        if (player.currentSkin == null) return;
        player.currentSkin.GetComponent<Animator>().SetTrigger(ConstDanceAnim.angryAnim);
        isTouch = true;
        turnOff = StartCoroutine(TurnOffTouch());
        spawnPoint.enabled = false;
        spawnRect.localRotation = Quaternion.Euler(12, 180, 0f);
    }
    IEnumerator TurnOffTouch()
    {
        yield return new WaitForSeconds(timeTouch);
        isTouch = false;
        spawnPoint.enabled = true;
        anim = StartCoroutine(ChangeAnimationRoutine());
        StopCoroutine(turnOff);
    }
    private void OnDisable()
    {
        StopCoroutine(anim);
    }
}
