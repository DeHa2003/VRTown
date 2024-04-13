using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;

public class PlayerFadeScreenScript : MonoBehaviour
{
    [SerializeField] private Color startColor = new(0, 0, 0, 0);
    [SerializeField] private Color toColor = Color.black;

    public void Initialize()
    {

    }

    public void StartFade(float time, Action actionToFinish)
    {
        Coroutines.StartRoutine(StartFade_Coroutine(time, toColor, actionToFinish));
    }


    private IEnumerator StartFade_Coroutine(float duration, Color ToColor, Action action)
    {
        Time.timeScale = 1.0f;
        SteamVR_Fade.Start(ToColor, duration);
        //yield return Coroutines.StartRoutine(SteamVR_Fade.Start(ToColor, duration));
        yield return new WaitForSeconds(duration + 1);
        action?.Invoke();
        //yield return new WaitForSeconds(1);
        SteamVR_Fade.Start(startColor, duration);
    }
}
