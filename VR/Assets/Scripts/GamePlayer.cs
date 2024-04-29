using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GamePlayer : MonoBehaviour, IPlayerMove, IPlayerLaser, IPlayerVibrationHand, IPlayerFadeScreen, IPlayerMenu
{
    [SerializeField] private HandButtons handButtons;
    [SerializeField] private PlayerMoveScript moveScript;
    [SerializeField] private PlayerFeetScript feetScript;
    [SerializeField] private PlayerLaserController laserControllerScript;
    [SerializeField] private PlayerMenuControl menuControlScript;
    [SerializeField] private PlayerVibrationHandDevice vibrationDeviceScript;
    [SerializeField] private PlayerFadeScreenScript playerFadeScreenScript;

    public void Initialize()
    {
        moveScript.Initialize();
        feetScript.Initialize();
        vibrationDeviceScript.Initialize();
        playerFadeScreenScript.Initialize();
        laserControllerScript.Initialize(handButtons);
        menuControlScript.Initialize(handButtons);

    }

    public void ActivateMenuController()
    {
        menuControlScript.ActivateMenuControl();
    }

    public void SetMenuData(TypeMenu typeMenu, MenuProperties menuProperties = null)
    {
        menuControlScript.SetMenuData(typeMenu, menuProperties);
    }

    public void DeactivateMenuController()
    {
        menuControlScript.DiactivateMenuControl();
    }

    public void InstantiateMenu()
    {
        menuControlScript.InstantiateMenu();
    }

    public void DestroyMenu()
    {
        menuControlScript.DestroyMenu();
    }

    public void ActivateLaserController()
    {
        laserControllerScript.ActivateLaserController();
    }

    public void DeactivateLaserController()
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

    public Vector2 GetDataLeftTouchpad()
    {
        return handButtons.GetLeftTouchpadData();
    }

    public Vector2 GetDataRightTouchpad()
    {
        return handButtons.GetLeftTouchpadData();
    }

    public void Vibrate(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        vibrationDeviceScript.Pulse(duration, frequency, amplitude, source);
    }

    public void Fade(float duration, Color color , Action actionToFinish = null)
    {
        playerFadeScreenScript.Fade(duration, color, actionToFinish);
    }

    public void TeleportToPosition(Vector3 vector)
    {
        moveScript.TeleportToPosition(vector);
    }
}

public interface IPlayerMove
{
    void SetSpeedMove(int speed);
    void SetDefaultSpeedMove();
    void TeleportToPosition(Vector3 vector);
    Vector2 GetDataLeftTouchpad();
    Vector2 GetDataRightTouchpad();
}

public interface IPlayerLaser
{
    void ActivateLaserController();
    void DeactivateLaserController();
}

public interface IPlayerVibrationHand
{
    void Vibrate(float duration, float frequency, float amplitude, SteamVR_Input_Sources source);
}

public interface IPlayerFadeScreen
{
    void Fade(float duration, Color color, Action actionToFinish = null);
}

public interface IPlayerMenu
{
    void InstantiateMenu();
    void DestroyMenu();
    void ActivateMenuController();
    void DeactivateMenuController();
    void SetMenuData(TypeMenu typeMenu, MenuProperties menuProperties = null);
}
