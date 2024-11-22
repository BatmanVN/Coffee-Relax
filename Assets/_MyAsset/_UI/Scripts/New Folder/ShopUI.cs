using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UICanvas
{
    [Header("UI Elements")]
    public ListDownButton listDown;
    public SpawnSkin cameraSkin;
    public ScrollRect content;
    public RectTransform[] viewPort;
    public Button backButton;
    public Toggle characterToggle;
    public Toggle cupToggle;

    [Header("Visual Elements")]
    public Text coinTextConner;
    public GameObject buttonManager;
    public GameObject upEffect;

    [Header("PanelTop")]
    public GameObject[] buttonTop;

    private Coroutine effect;

    private void OnEnable()
    {
        // Đặt trạng thái mặc định
        SetViewPort(0);
        UpdateCoinText(GameControllManager.Ins?.getcoin() ?? 0);

        // Đăng ký Observer
        Observer.AddObserver(UiAction.ChangeTextCoin, ChangeTextCoin);
    }

    private void Start()
    {
        // Thiết lập các sự kiện
        characterToggle.onValueChanged?.AddListener(CharacterButton);
        cupToggle.onValueChanged?.AddListener(CupButton);
        backButton.onClick?.AddListener(BackButton);

    }

    private void OnDestroy()
    {
        // Gỡ Observer khi ShopUI bị hủy
        Observer.RemoveObserver(UiAction.ChangeTextCoin, ChangeTextCoin);
    }

    public void ChangeTextCoin(object[] datas)
    {
        if (datas != null && datas.Length > 0 && datas[0] is int coin)
        {
            UpdateCoinText(coin);
        }
    }

    private void UpdateCoinText(int coin)
    {
        coinTextConner.text = coin.ToString();
    }

    public void BuyButton()
    {
        StartEffectCoroutine();
    }

    public void UpEffect(bool active)
    {
        if (upEffect != null)
            upEffect.SetActive(active);
    }

    private void StartEffectCoroutine()
    {
        if (effect != null)
            StopCoroutine(effect);

        effect = StartCoroutine(TurnOffEffect());
    }

    private IEnumerator TurnOffEffect()
    {
        yield return new WaitForSeconds(1);
        UpEffect(false);
    }

    public void BackButton()
    {
        Close(0);
        UIManager.Ins?.OpenUI<MainMenu_UI>();
    }

    public void CharacterButton(bool active)
    {
        if (active)
        {
            SetViewPort(0);
            cameraSkin?.SpawnCharacter();
        }
    }

    public void CupButton(bool active)
    {
        if (active)
        {
            SetViewPort(1);
            cameraSkin?.SpawnCup();
            Observer.Notify(UiAction.DestroySkin);
            Observer.Notify(UiAction.SetSkinEnable);
        }
    }

    private void SetViewPort(int index)
    {
        if (index < 0 || index >= viewPort.Length) return;

        for (int i = 0; i < viewPort.Length; i++)
        {
            bool isActive = i == index;
            viewPort[i]?.gameObject.SetActive(isActive);
            if (listDown?.downButtons != null && i < listDown.downButtons.Count)
                listDown.downButtons[i]?.gameObject.SetActive(isActive);
            buttonTop[i]?.SetActive(isActive);
        }

        if (content != null)
            content.content = viewPort[index];
    }
}
