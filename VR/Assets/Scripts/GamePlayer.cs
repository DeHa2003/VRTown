using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GamePlayer : MonoBehaviour, IPlayerMove, IPlayerLaser, IPlayerVibrationHand, IPlayerFadeScreen, IPlayerMenu
{
    [SerializeField] public HandButtons handButtons;

    [SerializeField] private PlayerCamera playerCamera;
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
        laserControllerScript.Initialize();
        menuControlScript.Initialize();

    }

    public void ActivateCamera()
    {
        playerCamera.ActivateCamera();
    }

    public void DeactivateCamera()
    {
        playerCamera.DeactivateCamera();
    }

    public void CheckCameraActivate()
    {
        playerCamera.CheckCamera();
    }

    public void ActivateMenuController()
    {
        //menuControlScript.ActivateMenuControl();
        handButtons.AddActionToUpperButton_RightHand(menuControlScript.CheckMenuPanel);

    }

    public void SetMenuData(TypeMenu typeMenu, MenuProperties menuProperties = null)
    {
        menuControlScript.SetMenuData(typeMenu, menuProperties);
    }

    public void DeactivateMenuController()
    {
        //menuControlScript.DiactivateMenuControl();
        handButtons.RemoveActionToUpperButton_RightHand(menuControlScript.CheckMenuPanel);
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
        //laserControllerScript.ActivateLaserController();
        handButtons.AddActionToUpperButton_LeftHand(laserControllerScript.CheckLaserPointer);
    }

    public void DeactivateLaserController()
    {
        //laserControllerScript.DeactivateLaserController();
        handButtons.RemoveActionToUpperButton_LeftHand(laserControllerScript.CheckLaserPointer);
    }

    public void ActivateMoveController()
    {
        moveScript.CheckActivateMove(true);
    }

    public void DeactivateMoveController()
    {
        moveScript.CheckActivateMove(false);
    }

    public void SetSpeedMove(int speed)
    {
        moveScript.SetSpeedMove(speed);
    }

    public void SetDefaultSpeedMove()
    {
        moveScript.SetDefaultSpeedMove();
    }



    public float GetDataLeftSqueeze()
    {
        return handButtons.GetLeftSqueezeData();
    }

    public float GetDataRightSqueeze()
    {
        return handButtons.GetRightSqueezeData();
    }

    public Vector2 GetDataLeftTouchpad()
    {
        return handButtons.GetLeftTouchpadData();
    }

    public Vector2 GetDataRightTouchpad()
    {
        return handButtons.GetRightTouchpadData();
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

    #region Events

    public void AddActionToUpperButton_LeftHand(Action action)
    {
        handButtons.AddActionToUpperButton_LeftHand(action);
    }

    public void RemoveActionToUpperButton_LeftHand(Action action)
    {
        handButtons.RemoveActionToUpperButton_LeftHand(action);
    }


    public void AddActionToUpperButton_RightHand(Action action)
    {
        handButtons.AddActionToUpperButton_RightHand(action);
    }

    public void RemoveActionToUpperButton_RightHand(Action action)
    {
        handButtons.RemoveActionToUpperButton_RightHand(action);
    }


    public void AddActionToTriggerButton_LeftHand(Action action)
    {
        handButtons.AddActionToTriggerButton_LeftHand(action);
    }

    public void RemoveActionToTriggerButton_LeftHand(Action action)
    {
        handButtons.RemoveActionToTriggerButton_LeftHand(action);
    }


    public void AddActionToTriggerButton_RightHand(Action action)
    {
        handButtons.AddActionToTriggerButton_RightHand(action);
    }

    public void RemoveActionToTriggerButton_RightHand(Action action)
    {
        handButtons.RemoveActionToTriggerButton_RightHand(action);
    }

    #endregion
}

public interface IPlayerMove
{
    void SetSpeedMove(int speed);
    void SetDefaultSpeedMove();
    void TeleportToPosition(Vector3 vector);
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
