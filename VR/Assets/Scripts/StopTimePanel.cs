using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimePanel : ScaleColliderPanel
{
    public override void OpenPanel()
    {
        if (tweenScale != null) { tweenScale.Kill(); }

        OnOpenUI?.Invoke();
        panel.SetActive(true);
        tweenScale = transform.DOScale(defaultScale, timeScale).SetUpdate(true).OnComplete(() =>
        {
            Time.timeScale = 0;
        });
    }

    public override void ClosePanel()
    {
        if (tweenScale != null) { tweenScale.Kill(); }

        OnCloseUI?.Invoke();
        tweenScale = transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        });
    }
}
