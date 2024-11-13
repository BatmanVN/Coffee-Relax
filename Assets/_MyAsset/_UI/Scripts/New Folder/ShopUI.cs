using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UICanvas
{
    public ScrollRect content;
    public RectTransform[] viewPort;
    public Button backButton;
    public Button characterButton;
    public Button cupButton;
    public Button useButton;
    public Button buyButton;
    public Button adsButton;
    [SerializeField] Animator anim;
    private string animName = "Character";

    private void OnEnable()
    {
        ChangeAnim("Idle");
        ChangeAnim("Charecter");
        content.content = viewPort[0];
        viewPort[0].gameObject.SetActive(true);
        viewPort[1].gameObject.SetActive(false);
    }
    private void Start()
    {
        ChangeAnim("Character");
        characterButton.onClick?.AddListener(CharacterButton);
        cupButton.onClick?.AddListener(CupButton);
        backButton.onClick?.AddListener(BackButton);

        //Observer.AddObserver("ChangeAnimButtonShop", ShopButton_2);
    }
    public void ChangeAnim(string animName)
    {
        if (this.animName != animName)
        {
            anim.ResetTrigger(this.animName);
            this.animName = animName;
            anim.SetTrigger(this.animName);
        }
    }

    public void BackButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<MainMenu_UI>();
    }
    public void CharacterButton()
    {
        ChangeAnim("Idle");
        ChangeAnim("Character");
        content.content = viewPort[0];
        viewPort[0].gameObject.SetActive(true);
        viewPort[1].gameObject.SetActive(false);

    }
    public void CupButton()
    {
        ChangeAnim("Idle");
        ChangeAnim("Cup");
        content.content = viewPort[1];
        viewPort[0].gameObject.SetActive(false);
        viewPort[1].gameObject.SetActive(true);
    }
}
