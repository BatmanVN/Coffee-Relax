using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewCharacter : Singleton<ViewCharacter>
{
    public List<BaseSkin> baseSkins;
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

    private void OnEnable()
    {
        SetData();
        Observer.AddObserver(UiAction.DestroySkin,DestroySkin);
        foreach (Transform skin in transform)
        {
            baseSkins.Add(skin.GetComponent<BaseSkin>());

        }
    }
    private void Start()
    {
        for (int i = 0; i < baseSkins.Count; i++)
        {
            baseSkins[i].skinId = skinsData.skinDatas[i].id;
        }
    }
    private void SetData()
    {
        GameObject character = Instantiate(skinsData.skinDatas[0].character_pref, spawnPoint.position, spawnPoint.rotation);
        character.transform.SetParent(spawnPoint.transform);
        currentSkin = character;
        useButton.SetActive(true);
        buyButton.SetActive(false);
    }

    public void SetStatusTextNoti(bool active, string text)
    {
        textNoti.gameObject.SetActive(active);
        textNoti.text = text;
    }

    private void DestroySkin(object[] datas)
    {
        if(currentSkin != null)
            Destroy(currentSkin);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.DestroySkin, DestroySkin);
    }
}
