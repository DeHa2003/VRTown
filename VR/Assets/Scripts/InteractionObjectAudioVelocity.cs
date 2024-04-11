using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]

public class InteractionObjectAudioVelocity : MonoBehaviour
{
    [SerializeField] private AudioClip grapSound;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private float dependenceVolume;

    private AudioSource audioS;
    private Rigidbody rb;
    public void Initialize()
    {
        audioS = GetComponent<AudioSource>();
        audioS.playOnAwake = false;
        audioS.spatialBlend = 0.9f;
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(rb == null) { return; }
        PlaySound(clips[Random.Range(0, clips.Count)], rb.velocity.magnitude / dependenceVolume);
    }

    public void OnPickUpObject()
    {
        PlaySound(grapSound, 1f);
    }

    private void PlaySound(AudioClip audioClip, float volume)
    {
        audioS.volume = volume;
        audioS.PlayOneShot(audioClip);
    }
}
