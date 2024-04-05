using DG.Tweening;
using UnityEngine;

public class ColliderMovePanel : ColliderPanel
{
    [SerializeField] private protected Transform from;
    [SerializeField] private protected Transform to;
    [SerializeField] private protected float timeMove;
    private protected Tween tweenMove;
    public override void OpenPanel()
    {
        base.OpenPanel();

        tweenMove?.Kill();
        tweenMove = transform.DOMove(to.position, timeMove);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        tweenMove?.Kill();
        tweenMove = transform.DOMove(from.position, timeMove);
    }

}
