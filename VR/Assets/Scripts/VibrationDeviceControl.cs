using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VibrationDeviceControl : PlayerComponentControl
{
    private PlayerVibrationHandDevice vibrationDevice;

    private void Awake()
    {
        Debug.Log("Дочерний класс");
        vibrationDevice = getPlayer.player.GetComponentInChildren<PlayerVibrationHandDevice>();
    }

    public void Vibration(float duration, float frequency, float amplitude, Valve.VR.SteamVR_Input_Sources input_Sources)
    {
        vibrationDevice.Pulse(duration, frequency, amplitude, input_Sources);
    }
}
