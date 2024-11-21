using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewCharacter : Singleton<ViewCharacter>
{
    public List<BaseSkinCharacter> baseSkins = new List<BaseSkinCharacter>();
    public SkinCharacterData skinsData;
    public GameObject buttonDown;
    public Transform spawnPoint;
    public GameObject currentSkin;
    public BaseSkinCharacter currentSelect;
    [Header("Price")]
    [SerializeField] public TextMeshProUGUI textPrice;
    [SerializeField] public GameObject useButton;
    [SerializeField] public GameObject buyButton;
    [Header("Text Notify")]
    [SerializeField] public Text textNoti;

    //public GameObject firstSpawn;
    protected override void Awake()
    {
        base.Awake();
        foreach (Transform skin in transform)
        {
            baseSkins.Add(skin.GetComponent<BaseSkinCharacter>());
        }
        SetSkinID();
    }
    private void OnEnable()
    {
        if (baseSkins.Count <= 0)
        {
            foreach (Transform skin in transform)
            {
                baseSkins.Add(skin.GetComponent<BaseSkinCharacter>());
            }
            SetSkinID();
        }
        Observer.AddObserver(UiAction.DestroySkin,DestroySkin);
        Observer.AddObserver(UiAction.StatusBuy, DontBuySkin);
        Observer.AddObserver(UiAction.StatusUsed, BoughtSkin);
    }

    private void Start()
    {
        
    }

    private void SetSkinID()
    {
        for (int i = 0; i < baseSkins.Count; i++)
        {
            baseSkins[i].skinId = skinsData.skinDatas[i].id;
        }
    }

    public void SetStatusTextNoti(bool active, string text)
    {
        textNoti.gameObject.SetActive(active);
        textNoti.text = text;
    }
    public void BoughtSkin(object[] datas)
    {
        useButton.SetActive(true);
        buyButton.SetActive(false);
    }
    public void DontBuySkin(object[] datas)
    {
        useButton.SetActive(false);
        buyButton.SetActive(true);
    }
    private void DestroySkin(object[] datas)
    {
        if (currentSkin != null)
        {
            Destroy(currentSkin);
        }
    }
    private void OnDisable()
    {
        baseSkins.Clear();
        if (currentSkin != null)
        {
            Destroy(currentSkin);
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.DestroySkin, DestroySkin);
        Observer.RemoveObserver(UiAction.StatusBuy, DontBuySkin);
        Observer.RemoveObserver(UiAction.StatusUsed, BoughtSkin);
    }
}
