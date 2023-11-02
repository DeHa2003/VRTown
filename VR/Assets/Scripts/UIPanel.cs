using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;
    private void OnEnable()
    {
        OnOpenUI?.Invoke();
    }

    private void OnDisable()
    {
        OnCloseUI?.Invoke();
    }

}
