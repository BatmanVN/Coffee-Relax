using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] public SoundsSO SO;
    public static SoundManager instance = null;
    private static AudioSource audioSource;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        SoundList soundList = instance.SO.sounds[(int)sound];
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
    public static int PlayIntSound(SoundType sound,int clipIndex, float volume = 1)
    {
        SoundList soundList = instance.SO.sounds[(int)sound];
        AudioClip[] clips = soundList.sounds;
        AudioClip randomClip = clips[clipIndex];
        if (audioSource != null)
        {
            // Dừng âm thanh hiện tại nếu đang phát
            if (audioSource.isPlaying)
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
        return clipIndex;
    }
}

[Serializable]
public struct SoundList
{
    [HideInInspector] public string name;
    [Range(0, 1)] public float volume;
    public AudioMixerGroup mixer;
    public AudioClip[] sounds;
}