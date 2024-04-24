using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIObject : MonoBehaviour
{
    [SerializeField] protected GameObject obj;
    [SerializeField] protected PanelsControl[] panelsControls;

    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    public virtual void Initialize() 
    {
        for (int i = 0; i < panelsControls.Length; i++)
        {
            panelsControls[i].Initialize();
        }
    }
    public virtual void Activate() 
    { 
        obj.SetActive(true);
        OnOpenUI?.Invoke();
    }
    public virtual void Deactivate() 
    {
        OnCloseUI?.Invoke();
        obj.SetActive(false);
    }
}
