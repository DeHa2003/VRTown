using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnOpenUI;
    public UnityEvent OnCloseUI;

    [SerializeField] VibrationDevice device;
    public float duration;
    public float frequency;
    public float amplitude;
    private void OnEnable()
    {
        if(device != null)
           device.Pulse(duration, frequency, amplitude, Valve.VR.SteamVR_Input_Sources.Any);
        OnOpenUI?.Invoke();
    }

    private void OnDisable()
    {
        OnCloseUI?.Invoke();
    }

}
