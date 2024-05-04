using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //public void FadeAction(float time, Action actionToFinish)
    //{
    //    Coroutines.StartRoutine(StartFade_CoroutineAction(time, toColor, actionToFinish));
    //}

    public void Fade(float time, Color to, Action action)
    {
        Coroutines.StartRoutine(StartFade_Coroutine(time, to, action));
    }

    private IEnumerator StartFade_Coroutine(float duration, Color toColor, Action action)
    {
        SteamVR_Fade.Start(toColor, duration);
        yield return new WaitForSeconds(duration + 1);
        action?.Invoke();
    }


    //private IEnumerator StartFade_CoroutineAction(float duration, Color toColor, Action action)
    //{
    //    Time.timeScale = 1.0f;
    //    SteamVR_Fade.Start(toColor, duration);
    //    yield return new WaitForSeconds(duration + 1);
    //    action?.Invoke();
    //    SteamVR_Fade.Start(startColor, duration);
    //}
}
