using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Panel : MonoBehaviour
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    [SerializeField] protected GameObject panel;
    [SerializeField] protected float timeScale;

    protected Vector3 defaultScale;
    protected Tween tweenScale;

    protected virtual void Awake()
    {
        defaultScale = panel.transform.localScale;
        panel.transform.localScale = Vector3.zero;
    }

    public virtual void OpenPanel()
    {
        if (tweenScale != null) { tweenScale.Kill(); }

        panel.SetActive(true);
        OnOpenUI?.Invoke();
        tweenScale = transform.DOScale(defaultScale, timeScale).SetUpdate(true);
    }

    public virtual void ClosePanel()
    {
        if (tweenScale != null) { tweenScale.Kill(); }

        OnCloseUI?.Invoke();
        tweenScale = transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
        {
            panel.SetActive(false);
        });
    }
}
