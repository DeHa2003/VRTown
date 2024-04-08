using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleColliderPanel : ColliderPanel
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    [SerializeField] protected float timeScale;

    protected Vector3 defaultScale;
    protected Tween tweenScale;
    protected bool isOpen = false;

    public override void Initialize()
    {
        defaultScale = panel.transform.localScale;
        panel.transform.localScale = Vector3.zero;
    }

    public override void OpenPanel()
    {
        if (isOpen == false) 
        {
            Debug.Log("Открытие панели");
            base.OpenPanel();
            OnOpenUI?.Invoke();

            tweenScale?.Kill();
            tweenScale = transform.DOScale(defaultScale, timeScale).SetUpdate(true);
        }
        isOpen = true;
    }

    public override void ClosePanel()
    {
        if (isOpen == true) 
        {
            Debug.Log("Закрытие панели");
            OnCloseUI?.Invoke();

            tweenScale?.Kill();
            tweenScale = transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
            {
                base.ClosePanel();
            });
        }
        isOpen = false;
    }
}
