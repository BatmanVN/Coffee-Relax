using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UICanvas
{
    public ListDownButton listDown;
    public SpawnSkin cameraSkin;
    public ScrollRect content;
    public RectTransform[] viewPort;
    public Button backButton;
    public Toggle characterToggle;
    public Toggle cupToggle;
 
    public Text coinTextConner;
    [SerializeField] Animator anim;
    private string animName = "Character";
    public GameObject buttonManager;

    private Coroutine effect;
    public GameObject upEffect;

    private void OnEnable()
    {
        ChangeAnim("Idle");
        ChangeAnim("Charecter");
        content.content = viewPort[0];
        viewPort[0].gameObject.SetActive(true);
        viewPort[1].gameObject.SetActive(false);
        listDown.downButtons[0].gameObject.SetActive(true);
        listDown.downButtons[1].gameObject.SetActive(false);
        Observer.AddObserver(UiAction.ChangeTextCoin,ChangeTextCoin);
        coinTextConner.text = GameControllManager.Ins.getcoin().ToString();
    }
    private void Start()
    {
        ChangeAnim("Character");
        characterToggle.onValueChanged?.AddListener(CharacterButton);
        cupToggle.onValueChanged?.AddListener(CupButton);
        backButton.onClick?.AddListener(BackButton);
        //buyButton.onClick?.AddListener(BuyButton);
        //coinTextConner.text = GameControllManager.Ins.getcoin().ToString();
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
    public void ChangeTextCoin(object[] datas)
    {
        if(datas == null ||datas.Length < 1 || !(datas[0] is int coin)) return;
        coinTextConner.text = coin.ToString();
    }
    public void BuyButton()
    {
        effect = StartCoroutine(TurnOffEffect());
    }
    public void UpEffect(bool active)
    {
        upEffect.SetActive(active);
    }
    public IEnumerator TurnOffEffect()
    {
        yield return new WaitForSeconds(1);
        UpEffect(false);
        StopCoroutine(effect);
    }
    public void BackButton()
    {
        Close(0);
        UIManager.Ins.OpenUI<MainMenu_UI>();
        
    }
    public void CharacterButton(bool active)
    {
        if (active)
        {
            ChangeAnim("Idle");
            ChangeAnim("Character");
            content.content = viewPort[0];
            viewPort[0].gameObject.SetActive(true);
            viewPort[1].gameObject.SetActive(false);
            cameraSkin.SpawnCharacter();
            listDown.downButtons[0].gameObject.SetActive(true);
            listDown.downButtons[1].gameObject.SetActive(false);
        }
        return;
    }
    public void CupButton(bool active)
    {
        if (active)
        {
            ChangeAnim("Idle");
            ChangeAnim("Cup");
            content.content = viewPort[1];
            viewPort[0].gameObject.SetActive(false);
            viewPort[1].gameObject.SetActive(true);
            listDown.downButtons[0].gameObject.SetActive(false);
            listDown.downButtons[1].gameObject.SetActive(true);
            cameraSkin.SpawnCup();
            Observer.Notify(UiAction.DestroySkin);
            Observer.Notify(UiAction.SetSkinEnable);
        }
        return;
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.ChangeTextCoin,ChangeTextCoin);
    }
}
