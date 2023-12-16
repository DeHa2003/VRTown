using System;
using UnityEngine;
using Valve.VR;

public class HandButtons : MonoBehaviour
{
    public static event Action OnClickRightHandMenu;
    public static event Action OnClickLeftHandMenu;

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
}
