using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    public void OpenPanel()
    {

        OnOpenUI?.Invoke();
    }

    public void ClosePanel()
    {
        OnCloseUI?.Invoke();
    }

}
