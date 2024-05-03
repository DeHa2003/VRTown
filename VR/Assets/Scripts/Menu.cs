using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public abstract class Menu : ScaleUIObject
{
    protected MenuProperties properties;

    public override void Deactivate()
    {
        if (isOpen)
        {
            Debug.Log("Закрытие панели");

            tweenScale?.Kill();
            tweenScale = transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
        isOpen = false;
    }

    public virtual void SetData(string nameTarget, MenuProperties menuProperties)
    {

    }
}
