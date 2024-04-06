using System;
using UnityEngine;
using Valve.VR;

public class HandButtons : MonoBehaviour
{
    public event Action OnClickRightHandMenu;
    public event Action OnClickLeftHandMenu;

    [SerializeField] SteamVR_Action_Boolean menu;

    private void Update()
    {
        if (menu.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            OnClickLeftHandMenu?.Invoke();
        }
        else if(menu.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            OnClickRightHandMenu?.Invoke();
        }
    }

    public void AddActionToLeftHand(Action action)
    {
        OnClickLeftHandMenu += action;
    }

    public void RemoveActionToLeftHand(Action action)
    {
        OnClickLeftHandMenu -= action;
    }

    public void AddActionToRightHand(Action action)
    {
        OnClickRightHandMenu += action;
    }

    public void RemoveActionToRightHand(Action action)
    {
        OnClickRightHandMenu -= action;
    }
}
