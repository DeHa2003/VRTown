using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class PanelAnimationInteractor : Interactor
    {
        public void CanvasGroupAlpha(CanvasGroup canvasGroup, float from, float to, float time)
        {
            Coroutines.StartRoutine(SmoothVal(canvasGroup, from, to, time));
        }
        private IEnumerator SmoothVal(CanvasGroup canvasGroup, float from, float to, float timer)
        {
            float t = 0.0f;
            canvasGroup.alpha = from;
            
            while (t < 1.0f)
            {
                t += Time.deltaTime * (1.0f / timer);
                if(canvasGroup != null)
                   canvasGroup.alpha = Mathf.Lerp(from, to, t); //Может быть удалён
                yield return 0;
            }
        }
    }
}
