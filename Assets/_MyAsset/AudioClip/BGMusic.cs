using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[RequireComponent(typeof(AudioSource))]
public class BGMusic : MonoBehaviour
{
    public static BGMusic instance = null;
    [SerializeField] public BackGroundMusic BG;
    [SerializeField] public static AudioSource audioSource;


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public static void PlayRandomSound(MusicType sound, float volume = 1)
    {
        BGMusicList soundList = instance.BG.musics[(int)sound];
        AudioClip[] clips = soundList.sounds;
        int clipIndex = UnityEngine.Random.Range(0, clips.Length);
        AudioClip randomClip = clips[clipIndex];

        if (audioSource)
        {
            // Dừng âm thanh hiện tại nếu đang phát
            if (audioSource.clip != null)
            {
                audioSource.Stop();
                audioSource.clip = null;// Dừng âm thanh đang phát
            }

            // Cập nhật âm thanh mới
            audioSource.outputAudioMixerGroup = soundList.mixer;
            audioSource.clip = randomClip;
            audioSource.volume = volume * soundList.volume;

            // Phát âm thanh mới
            audioSource.Play();
        }
        else
        {
            audioSource.outputAudioMixerGroup = soundList.mixer;
            audioSource.PlayOneShot(randomClip, volume * soundList.volume);
        }
    }
}

    [Serializable]
public struct BGMusicList
{
    [HideInInspector] public string name;
    [Range(0, 1)] public float volume;
    public AudioMixerGroup mixer;
    public AudioClip[] sounds;
}

