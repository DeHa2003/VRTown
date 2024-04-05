using DG.Tweening;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class MovePanel : Panel
{
    [SerializeField] protected Vector3 from;
    [SerializeField] protected Vector3 to;
    [SerializeField] protected float time;
    [SerializeField] protected CanvasGroup canvasGroup;
    protected PanelAnimationInteractor animationInteractor;
    protected Tween tween;
    public override void Initialize()
    {
        base.Initialize();
        animationInteractor = Game.GetInteractor<PanelAnimationInteractor>();
    }

    public override void ClosePanel()
    {
        if (tween != null) { tween.Kill(); }

        tween = panel.transform.DOLocalMove(from, time).OnComplete(() => panel.SetActive(false));
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }

    public override void OpenPanel()
    {
        if (tween != null) { tween.Kill(); }

        PlaySound();
        panel.SetActive(true);
        tween = panel.transform.DOLocalMove(to, time);
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    protected virtual void PlaySound()
    {
        audioInteractor.PlayEffectSound("OpenMain");
    }
}
