using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VibrationDeviceControl : PlayerComponentControl
{
    private VibrationDevice vibrationDevice;

    private void Awake()
    {
        Debug.Log("Дочерний класс");
        vibrationDevice = getPlayer.player.GetComponentInChildren<VibrationDevice>();
    }

    public void Vibration(float duration, float frequency, float amplitude, Valve.VR.SteamVR_Input_Sources input_Sources)
    {
        vibrationDevice.Pulse(duration, frequency, amplitude, input_Sources);
    }
}
