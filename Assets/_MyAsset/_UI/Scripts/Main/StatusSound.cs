using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusSound : MonoBehaviour
{
    [SerializeField] private GameObject[] statusButton;
    [SerializeField] private Toggle turnOn;
    [SerializeField] private Toggle turnOff;
    [SerializeField] protected AudioSource music;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        turnOn.onValueChanged?.AddListener(TurnOff);
        turnOff.onValueChanged?.AddListener(TurnOn);
    }

    protected void TurnOn(bool active)
    {
        if (active)
        {
            statusButton[1].SetActive(false);
            statusButton[0].SetActive(true);
            music.gameObject.SetActive(true);
        }
    }
    protected void TurnOff(bool active)
    {
        if (active)
        {
            statusButton[0].SetActive(false);
            statusButton[1].SetActive(true);
            music.gameObject.SetActive(false);
        }
    }
}
