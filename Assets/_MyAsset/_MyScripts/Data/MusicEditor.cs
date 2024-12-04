
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

[CustomEditor(typeof(BackGroundMusic))]
public class MusicEditor : Editor
{
    private void OnEnable()
    {
        ref BGMusicList[] musicList = ref ((BackGroundMusic)target).musics;

        if (musicList == null)
            return;

        string[] names = Enum.GetNames(typeof(MusicType));
        bool differentSize = names.Length != musicList.Length;

        Dictionary<string, BGMusicList> sounds = new();

        if (differentSize)
        {
            for (int i = 0; i < musicList.Length; ++i)
            {
                sounds.Add(musicList[i].name, musicList[i]);
            }
        }

        Array.Resize(ref musicList, names.Length);
        for (int i = 0; i < musicList.Length; i++)
        {
            string currentName = names[i];
            musicList[i].name = currentName;
            if (musicList[i].volume == 0) musicList[i].volume = 1;

            if (differentSize)
            {
                if (sounds.ContainsKey(currentName))
                {
                    BGMusicList current = sounds[currentName];
                    UpdateElement(ref musicList[i], current.volume, current.sounds, current.mixer);
                }
                else
                    UpdateElement(ref musicList[i], 1, new AudioClip[0], null);

                static void UpdateElement(ref BGMusicList element, float volume, AudioClip[] sounds, AudioMixerGroup mixer)
                {
                    element.volume = volume;
                    element.sounds = sounds;
                    element.mixer = mixer;
                }
            }
        }
    }
}
#endif
