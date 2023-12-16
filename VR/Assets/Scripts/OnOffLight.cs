using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class OnOffLight : MonoBehaviour
{
    [SerializeField] private GameObject lighthing;
    [SerializeField] private AudioClip onClip;
    [SerializeField] private AudioClip offClip;

    [SerializeField] private UnityEvent OnActivateLight;
    [SerializeField] private UnityEvent OnDeactivateLight;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.spatialBlend = 0.9f;
        source.volume = 0.8f;
        source.playOnAwake = false;
    }
    public void SwitchActivating()
    {
        if (lighthing.activeSelf)
        {
            OnLighting(source, offClip, false);
            OnDeactivateLight.Invoke();
        }
        else
        {
            OnLighting(source, onClip, true);
            OnActivateLight.Invoke();
        }
    }

    private void OnLighting(AudioSource audioSource, AudioClip audioClip, bool isActivateLight)
    {
        PlaySound(audioSource, audioClip);
        Light(isActivateLight);
    }

    private void Light(bool isActivate)
    {
        lighthing.SetActive(isActivate);
    }

    private void PlaySound(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
