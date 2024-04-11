using System;
using UnityEngine;
using Valve.VR;

public class HandButtons : MonoBehaviour
{
    //TEST

    public bool isNoneVR = false;

    //
    public event Action OnClickUpperRightHandMenu;
    public event Action OnClickUpperLeftHandMenu;

    [SerializeField] SteamVR_Action_Boolean UPPER_BUTTON;

    private void Update()
    {

        if (isNoneVR)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                OnClickUpperLeftHandMenu?.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                OnClickUpperRightHandMenu?.Invoke();
            }
        }
        else
        {
            
            if (UPPER_BUTTON.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                OnClickUpperLeftHandMenu?.Invoke();
            }
            else if (UPPER_BUTTON.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                OnClickUpperRightHandMenu?.Invoke();
            }
        }
    }

    public void AddActionToLeftHand(Action action)
    {
        OnClickUpperLeftHandMenu += action;
    }

    public void RemoveActionToLeftHand(Action action)
    {
        OnClickUpperLeftHandMenu -= action;
    }

    public void AddActionToRightHand(Action action)
    {
        OnClickUpperRightHandMenu += action;
    }

    public void RemoveActionToRightHand(Action action)
    {
        OnClickUpperRightHandMenu -= action;
    }
}
