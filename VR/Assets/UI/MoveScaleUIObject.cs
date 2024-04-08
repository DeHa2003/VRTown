using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScaleUIObject : UIObject
{
    [SerializeField] private Transform moveFrom;
    [SerializeField] private Transform moveTo;

    [SerializeField] private float timeMove;
    [SerializeField] private float timeScale;

    private Vector3 defaultScale;
    private Tween tweenMove;
    private Tween tweenScale;
    private bool isOpen = false;

    public override void Initialize()
    {
        base.Initialize();
        defaultScale = obj.transform.localScale;
        obj.transform.localScale = Vector3.zero;
        obj.transform.position = moveFrom.position;
    }

    public override void Activate()
    {
        if (!isOpen)
        {
            Debug.Log("Открытие панели");
            base.Activate();

            tweenScale?.Kill();
            tweenMove?.Kill();
            tweenScale = obj.transform.DOScale(defaultScale, timeScale).SetUpdate(true);
            tweenMove = obj.transform.DOMove(moveTo.position, timeMove);
        }
        isOpen = true;
    }

    public override void Deactivate()
    {
        if (isOpen)
        {
            Debug.Log("Закрытие панели");

            tweenMove?.Kill();
            tweenScale?.Kill();
            tweenMove = obj.transform.DOMove(moveFrom.position, timeMove);
            tweenScale = obj.transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
            {
                base.Deactivate();
            });
        }
        isOpen = false;
    }
}
