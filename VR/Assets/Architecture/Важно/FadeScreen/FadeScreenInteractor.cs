using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

namespace Lessons.Architecture
{
    public class FadeScreenInteractor : Interactor
    {
        //[SerializeField] private Color startColor;
        //[SerializeField] private Color endColor;
        //[SerializeField] private float duration;

        //public IEnumerator LoadSceneCoroutine(int sceneNumber)
        //{
        //    Time.timeScale = 1.0f;
        //    SteamVR_Fade.Start(startColor, duration);

        //    yield return new WaitForSeconds(duration);
        //    SceneManager.LoadScene(sceneNumber);


        //    SteamVR_Fade.Start(endColor, duration);
        //}

        public void StartFade(float time, Color to, Action actionToFinish = null)
        {
            Coroutines.StartRoutine(StartFade_Coroutine(time, to, actionToFinish));
        }

        public void StartFadeToTransition(float time, int sceneNumber)
        {
            Coroutines.StartRoutine(StartFade_Coroutine(time, Color.black,() =>
            {
                SceneManager.LoadScene(sceneNumber);
            }));
        }


        private IEnumerator StartFade_Coroutine(float duration, Color ToColor, Action action)
        {
            Time.timeScale = 1.0f;
            SteamVR_Fade.Start(ToColor, duration);

            yield return new WaitForSeconds(duration);

            action?.Invoke();
        }
    }
}
