using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioS;
    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        audioS.Play();
    }
}
