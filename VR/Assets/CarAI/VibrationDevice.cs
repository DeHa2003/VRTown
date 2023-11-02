using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VibrationDevice : MonoBehaviour
{
    public SteamVR_Action_Vibration vibration;

    public void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        vibration.Execute(0, duration, frequency, amplitude, source);
    }
}
