using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMachine : MonoBehaviour
{
    public GameObject machine;
    public Item_type machineType;
    public float time = 0.3f;

    protected virtual void PlaySoundGate()
    {
        SoundManager.PlaySound(SoundType.Gate);
    }
}
