using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenAndCloseScene : MonoBehaviour
{
    public UnityEvent EventOnOpenScene;
    public UnityEvent EventOnCloseScene;
    private void Start()
    {
        EventOnOpenScene?.Invoke();
    }

    private void OnDestroy()
    {
        EventOnCloseScene?.Invoke();
    }
}
