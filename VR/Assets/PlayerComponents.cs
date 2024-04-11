using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerComponents : MonoBehaviour
{
    [SerializeField] private HandButtons handButtons;
    [SerializeField] private PlayerMoveScript moveScript;
    [SerializeField] private PlayerFeetScript feetScript;
    [SerializeField] private PlayerLaserController laserControllerScript;
    [SerializeField] private PlayerMenuControl menuControlScript;
    [SerializeField] private PlayerVibrationHandDevice handDeviceScript;

    public void Initialize()
    {
        moveScript.Initialize();
        feetScript.Initialize();
        handDeviceScript.Initialize();
        laserControllerScript.Initialize(handButtons);
        menuControlScript.Initialize(handButtons);
    }

    //public void ActivateMenuControl(PanelsControl menuPref)
    //{
    //    menuControlScript.ActivateMenuControl(menuPref);
    //}

    public void DiactivateMenuControl()
    {
        menuControlScript.DiactivateMenuControl();
    }

    public void ActivateLaserControl()
    {
        laserControllerScript.ActivateLaserController();
    }

    public void DeactivateLaserControl()
    {
        laserControllerScript.DeactivateLaserController();
    }

    public void SetSpeedMove(int speed)
    {
        moveScript.SetSpeedMove(speed);
    }

    public void SetDefaultSpeedMove()
    {
        moveScript.SetDefaultSpeedMove();
    }

    public void ActivateVibration(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        handDeviceScript.Pulse(duration, frequency, amplitude, source);
    }
}
