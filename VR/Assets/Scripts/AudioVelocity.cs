using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]

public class AudioVelocity : MonoBehaviour
{
    [SerializeField] private AudioClip grapSound;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private float dependenceVolume;

    private AudioSource audio;
    private Rigidbody rb;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.spatialBlend = 0.9f;
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlaySound(clips[Random.Range(0, clips.Count)], rb.velocity.magnitude / dependenceVolume);
    }

    public void OnPickUpObject()
    {
        PlaySound(grapSound, 1f);
    }

    private void PlaySound(AudioClip audioClip, float volume)
    {
        audio.clip = audioClip;
        audio.volume = volume;
        audio.Play();
    }
}
