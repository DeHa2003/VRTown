using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LevelVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    public void SetVideoClip(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
    }

    public void Play()
    {
        videoPlayer.Play();
    }
}
