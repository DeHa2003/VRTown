using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MoveUIObject : UIObject
{
    [SerializeField] private Transform from;
    [SerializeField] private Transform to;

    [SerializeField] private float timeMove;

    private Tween tweenMove;
    private bool isOpen = false;
    public override void Activate()
    {
        if (!isOpen)
        {
            base.Activate();

            tweenMove?.Kill();
            tweenMove = transform.DOMove(to.position, timeMove);
        }
        isOpen = true;
    }

    public override void Deactivate()
    {
        if (isOpen)
        {
            tweenMove?.Kill();
            tweenMove = transform.DOMove(from.position, timeMove).OnComplete(() =>
            {
                base.Deactivate();
            });
        }
        isOpen = false;
    }
}
