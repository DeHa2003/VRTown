using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVPanel : ColliderPanel
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject LoopButton;
    [SerializeField] private GameObject notLoopButton;

    [SerializeField] private TextMeshProUGUI volumeSize;

    //private void OnEnable()
    //{
    //    for (int i = 0; i < buttonsColliders.Count; i++)
    //    {
    //        buttonsColliders[i].enabled = true;
    //    }
    //}

    //private void OnDisable()
    //{
    //    for (int i = 0; i < buttonsColliders.Count; i++)
    //    {
    //        buttonsColliders[i].enabled = false;
    //    }
    //}

    public void PlayORPauseVideo(bool isPlaying)
    {
        if (isPlaying)
        {
            playButton.SetActive(false);
            pauseButton.SetActive(true);
            videoPlayer.Play();
        }
        else
        {
            pauseButton.SetActive(false);
            playButton.SetActive(true);
            videoPlayer.Pause();
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume += volume;
        volumeSize.text = (Mathf.Round(audioSource.volume * 100)).ToString();
    }

    //100 = 1
    //95 = 0.95
    //90 = 0.9

    public void LoopingVideo(bool isLooping)
    {
        if (isLooping)
        {
            LoopButton.SetActive(false);
            notLoopButton.SetActive(true);
            if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
            }
            videoPlayer.isLooping = true;
        }
        else
        {
            notLoopButton.SetActive(false);
            LoopButton.SetActive(true);
            videoPlayer.isLooping = false;
        }
    }

    public void ChangeFrameVideo(int timeSkip)
    {
        videoPlayer.time += timeSkip;
    }

    public void PlayVideoClip(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (videoPlayer.isPlaying)
        {
            playButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }
    }
}
