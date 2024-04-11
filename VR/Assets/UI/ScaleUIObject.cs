using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ScaleUIObject : UIObject
{
    [SerializeField] private float timeScale;

    private Vector3 defaultScale;
    private Tween tweenScale;
    private bool isOpen = false;

    public override void Initialize()
    {
        base.Initialize();

        defaultScale = obj.transform.localScale;
        obj.transform.localScale = Vector3.zero;
    }

    public override void Activate()
    {
        if (!isOpen)
        {
            Debug.Log("Открытие панели");
            base.Activate();

            tweenScale?.Kill();
            tweenScale = transform.DOScale(defaultScale, timeScale).SetUpdate(true);
        }
        isOpen = true;
    }

    public override void Deactivate()
    {
        if (isOpen)
        {
            Debug.Log("Закрытие панели");

            tweenScale?.Kill();
            tweenScale = transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
            {
                base.Deactivate();
            });
        }
        isOpen = false;
    }
}
