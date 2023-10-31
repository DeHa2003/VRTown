using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LevelVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private VideoClip[] videoClips;

    public void PlayClip(int numberClip)
    {
        videoPlayer.clip = videoClips[numberClip];
        videoPlayer.Play();
    }
}
