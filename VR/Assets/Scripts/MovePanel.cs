using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePanel : Panel
{
    [SerializeField] private Transform from;
    [SerializeField] private Transform to;

    [SerializeField] private float timeMove;
    private Tween tweenMove;
    public override void OpenPanel()
    {
        base.OpenPanel();

        if (tweenMove != null) { tweenScale.Kill(); }
        tweenMove = transform.DOMove(to.position, timeMove);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        if (tweenMove != null) { tweenScale.Kill(); }
        tweenMove = transform.DOMove(from.position, timeMove);
    }

}
