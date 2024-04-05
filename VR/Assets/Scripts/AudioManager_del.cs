using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string nameSound;
    public AudioSource audio;
    public AudioClip audioClip;
    public bool isPlayOnAwake = false;
    public bool isLoop = false;
    [Range(0f, 1f)] public float volume = 1;
    [Range(-1f, 1f)] public float pitch = 1;
    [Range(0f, 1f)] public float spatialBlend = 0;
    public TypeAudioSource typeAudio;

    public enum TypeAudioSource
    {
        background,
        LoseGame,
        CompletedGame,
        other
    }
}

public class AudioManager_del : MonoBehaviour
{
    public List<Sound> sounds;

    public static AudioManager_del instance;

    private List<AudioSource> audios = new List<AudioSource>();

    private AudioClip clip;
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        foreach(Sound s in sounds)
        {
            s.audio.clip = s.audioClip;
            s.audio.playOnAwake = s.isPlayOnAwake;
            s.audio.loop = s.isLoop;
            if (s.isPlayOnAwake)
            {
                s.audio.Play();
            }
            s.audio.volume = s.volume;
            s.audio.pitch = s.pitch;
            s.audio.spatialBlend = s.spatialBlend;
        }
    }

    public void AddAudio(string name ,AudioSource audio, AudioClip audioClip, bool isPlayOnAwake = false, bool isLoop = false, float volume = 1, float pitch = 1, float spatialBlend = 1, Sound.TypeAudioSource typeAudioSource = Sound.TypeAudioSource.other)
    {
        Sound sound = new Sound();
        sound.nameSound = name;
        sound.audio = audio;
        sound.audioClip = audioClip;
        sound.isPlayOnAwake = isPlayOnAwake;
        sound.isLoop = isLoop;
        sound.volume = volume;
        sound.pitch = pitch;
        sound.spatialBlend = spatialBlend;
        sound.typeAudio = typeAudioSource;
        sounds.Add(sound);
    }

    public void Play(Sound.TypeAudioSource typeAudioSource)
    {
        foreach (AudioSource audioSource in FindAudio(typeAudioSource))
        {
            audioSource.Play();
        }
    }

    public void PlayLoseGameSound(Sound.TypeAudioSource typeAudioSource)
    {
        foreach(AudioSource audioSource in FindAudio(typeAudioSource))
        {
            audioSource.Play();
        }
    }

    public void Test()
    {
        Debug.Log("Тест 2n/34/21/ac");
    }

    public void Play(string nameAudio)
    {
        Sound s = Array.Find(sounds.ToArray(), sound => sound.nameSound == nameAudio);
        s?.audio.Play();
    }

    public List<AudioSource> FindAudio(Sound.TypeAudioSource typeAudioSource)
    {
        foreach (Sound s in sounds)
        {
            if(s.typeAudio == typeAudioSource)
            {
                audios.Add(s.audio);
            }
        }
        Debug.Log(audios.Count);
        return audios;
    }
}
