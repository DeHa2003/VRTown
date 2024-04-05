using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio resources")]
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioSource effectSource;
    private AudioSource otherSource;
    [Header("Audio clips")]
    [SerializeField] private AudioClip[] backgroundClips;
    [SerializeField] private AudioClip[] otherClips;



    public void PlayBackgroundSound(string clipName)
    {
        PlaySound(clipName, backgroundClips, backgroundSource);
    }

    public void PlayEffectSound(string clipName)
    {
        PlaySound(clipName, otherClips, effectSource);
    }

    public void PlayOtherSound(AudioSource audioSource, string clipName, float volume, float spatialBlend)
    {
        if(volume <= effectSource.volume)
        {
            audioSource.volume = volume;
        }
        else
        {
            audioSource.volume = effectSource.volume;
        }
        audioSource.spatialBlend = spatialBlend;
        PlaySound(clipName, otherClips, audioSource);
    }



    public void ChangeVolumeBackgroundSound(float value)
    {
        ChangeVolume(backgroundSource, value);
    }

    public void ChangeVolumeEffectsSound(float value)
    {
        ChangeVolume(effectSource, value);
    }



    private void ChangeVolume(AudioSource source, float volume)
    {
        source.volume = volume;
    }

    private void PlaySound(string clipName, AudioClip[] clips, AudioSource audioSource)
    {
        AudioClip audioClip = GetAudioClipByName(clipName, clips);
        if(audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"Аудиоклип {clipName} не был найден");
        }
    }

    private AudioClip GetAudioClipByName(string clipName, AudioClip[] audioClips)
    {
        foreach(AudioClip clip in audioClips)
        {
            if(clip.name == clipName)
            {
                return clip;
            }
        }
        return null;
    }
}
