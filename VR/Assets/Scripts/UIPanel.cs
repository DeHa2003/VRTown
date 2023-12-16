using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    [SerializeField] private GameObject panel;
    [SerializeField] private Transform from;
    [SerializeField] private Transform to;

    [SerializeField] private float timeMove;
    [SerializeField] private float timeScale;

    private Vector3 defaultScale;
    private Tween tweenScale;
    private Tween tweenMove;
    private void Awake()
    {
        defaultScale = panel.transform.localScale;
        panel.transform.localScale = Vector3.zero;
    }

    public void OpenPanel()
    {
        if (tweenScale != null) { tweenScale.Kill(); }
        if (tweenMove != null) { tweenScale.Kill(); }

        OnOpenUI?.Invoke();
        panel.SetActive(true);
        tweenScale = transform.DOScale(defaultScale, timeScale);
        tweenMove = transform.DOMove(to.position, timeMove);
    }

    public void ClosePanel()
    {
        if (tweenScale != null) { tweenScale.Kill(); }
        if (tweenMove != null) { tweenScale.Kill(); }

        OnCloseUI?.Invoke();
        tweenScale = transform.DOScale(Vector3.zero, timeScale).OnComplete(() =>
        {
            panel.SetActive(false);
        });
        tweenMove = transform.DOMove(from.position, timeMove);
    }

}
