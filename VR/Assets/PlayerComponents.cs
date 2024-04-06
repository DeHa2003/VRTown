using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerComponents : MonoBehaviour
{
    [SerializeField] private HandButtons handButtons;
    [SerializeField] private PlayerMoveScript moveScript;
    [SerializeField] private PlayerFeetScript feetScript;
    [SerializeField] private PlayerLaserController laserController;
    [SerializeField] private PlayerMenuControl menuControl;
    [SerializeField] private PlayerVibrationHandDevice handDevice;

    public void Initialize()
    {
        moveScript.Initialize();
        feetScript.Initialize();
        handDevice.Initialize();
        laserController.Initialize(handButtons);
        menuControl.Initialize(handButtons);
    }

    public void ActivateMenuControl(GameObject menuPref)
    {
        menuControl.ActivateMenuControl(menuPref);
    }

    public void DiactivateMenuControl()
    {
        menuControl.DiactivateMenuControl();
    }

    public void ActivateLaserControl()
    {
        laserController.ActivateLaserController();
    }

    public void DeactivateLaserControl()
    {
        laserController.DeactivateLaserController();
    }

    public void ActivateVibration(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        handDevice.Pulse(duration, frequency, amplitude, source);
    }
}
