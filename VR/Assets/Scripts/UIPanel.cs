using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    [SerializeField] protected GameObject panel;
    [SerializeField] protected float timeScale;

    protected Vector3 defaultScale;
    protected Tween tweenScale;
    protected bool isOpen = false;

    protected virtual void Awake()
    {
        defaultScale = panel.transform.localScale;
        panel.transform.localScale = Vector3.zero;
    }

    public virtual void OpenPanel()
    {
        if (isOpen == false) 
        {
            Debug.Log("Открытие панели");
            panel.SetActive(true);
            OnOpenUI?.Invoke();

            tweenScale?.Kill();
            tweenScale = transform.DOScale(defaultScale, timeScale).SetUpdate(true);
        }
        isOpen = true;
    }

    public virtual void ClosePanel()
    {
        if (isOpen == true) 
        {
            Debug.Log("Закрытие панели");
            OnCloseUI?.Invoke();

            tweenScale?.Kill();
            tweenScale = transform.DOScale(Vector3.zero, timeScale).SetUpdate(true).OnComplete(() =>
            {
                panel.SetActive(false);
            });
        }
        isOpen = false;
    }
}
