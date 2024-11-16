using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewCharacter : Singleton<ViewCharacter>
{
    public List<BaseSkin> baseSkins;
    //public List<GameObject > gameObjects;
    public SkinCharacterData skinsData;
    public GameObject buttonDown;
    public Transform spawnPoint;
    public GameObject currentSkin;
    [Header("Price")]
    [SerializeField] public TextMeshProUGUI textPrice;
    [SerializeField] public GameObject useButton;
    [SerializeField] public GameObject buyButton;
    [Header("Text Notify")]
    [SerializeField] public Text textNoti;
    //public GameObject firstSpawn;
    private void OnEnable()
    {
        Observer.AddObserver(UiAction.DestroySkin,DestroySkin);
        Observer.AddObserver(UiAction.StatusBuy, DontBuySkin);
        Observer.AddObserver(UiAction.StatusUsed, BoughtSkin);
        foreach (Transform skin in transform)
        {
            baseSkins.Add(skin.GetComponent<BaseSkin>());
        }
        SetSkinID();
        SetUIOnEnable();
    }

    private void Start()
    {
        //SetUIOnEnable();
    }

    public void SetUIOnEnable()
    {
        for (int i = 0; i < baseSkins.Count; i++)
        {
            Observer.Notify(UiAction.UpdateUsedObject, baseSkins[i].skinName);
            if (baseSkins[i].isUse)
            {
                currentSkin = Instantiate(skinsData.skinDatas[i].character_pref, spawnPoint.position, spawnPoint.rotation);
                currentSkin.transform.SetParent(spawnPoint.transform);
                //currentSkin = firstSpawn;
                useButton.SetActive(true);
                buyButton.SetActive(false);
            }
        }
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
        if(datas == null || datas.Length < 1 || !(datas[0] is GameObject current)) return;
        if (current != null)
        {
            Destroy(current);
            
        }
    }

    private void OnDisable()
    {
        baseSkins.Clear();
        Destroy(currentSkin);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.DestroySkin, DestroySkin);
        Observer.RemoveObserver(UiAction.StatusBuy, DontBuySkin);
        Observer.RemoveObserver(UiAction.StatusUsed, BoughtSkin);
    }
}
