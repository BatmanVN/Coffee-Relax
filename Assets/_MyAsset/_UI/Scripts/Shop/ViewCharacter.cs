using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewCharacter : MonoBehaviour
{
    public List<Button> buttons;
    public SkinCharacterData skinsData;
    public GameObject buttonDown;
    public Transform spawnPoint;
    public GameObject currentSkin;
    [Header("Price")]
    [SerializeField] TextMeshProUGUI textPrice;
    //[Header("Buy/NotBuy")]
    //[SerializeField] Text textOwnStatus;
    private void OnEnable()
    {
        SetData();
        Observer.AddObserver(UiAction.DestroySkin,DestroySkin);
        foreach (Transform button in transform)
        {
            buttons.Add(button.GetComponent<Button>());
        }
    }
    private void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick?.AddListener(() => InsCharacter(index));
        }
    }
    private void SetData()
    {
        GameObject character = Instantiate(skinsData.skinDatas[0].character_pref, spawnPoint.position, spawnPoint.rotation);
        character.transform.SetParent(spawnPoint.transform);
        currentSkin = character;
        textPrice.text = skinsData.skinDatas[0].price.ToString();
        //textOwnStatus.text = skinsData.skinDatas[0].price.ToString();
    }
    private void InsCharacter(int currentID)
    {
        GameObject character = Instantiate(skinsData.skinDatas[currentID].character_pref, spawnPoint.position, spawnPoint.rotation);
        character.transform.SetParent(spawnPoint.transform);
        Destroy(currentSkin);
        currentSkin = character;
        textPrice.text = skinsData.skinDatas[currentID].price.ToString();
        buttonDown.SetActive(true);
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
