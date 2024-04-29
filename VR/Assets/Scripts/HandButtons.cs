using System;
using UnityEngine;
using Valve.VR;

public class HandButtons : MonoBehaviour
{
    //TEST

    public bool isNoneVR = false;

    //
    public event Action<Vector2> OnChangedValueTouchpad_LeftHand;
    public event Action<Vector2> OnChangedValueTouchpad_RightHand;
    public event Action OnClickUpperRightHandMenu;
    public event Action OnClickUpperLeftHandMenu;

    [SerializeField] private SteamVR_Action_Boolean UPPER_BUTTON;
    [SerializeField] private SteamVR_Action_Vector2 touchpad_Left;
    [SerializeField] private SteamVR_Action_Vector2 touchpad_Right;

    private Vector2 leftTouchpadVector2;
    private Vector2 rightTouchpadVector2;

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

            leftTouchpadVector2 = touchpad_Left.GetAxis(SteamVR_Input_Sources.LeftHand); 
            OnChangedValueTouchpad_LeftHand?.Invoke(leftTouchpadVector2);

            rightTouchpadVector2 = touchpad_Right.GetAxis(SteamVR_Input_Sources.RightHand);
            OnChangedValueTouchpad_RightHand?.Invoke(rightTouchpadVector2);
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

    public Vector2 GetLeftTouchpadData()
    {
        return leftTouchpadVector2;
    }

    public Vector2 GetRightTouchpadData()
    {
        return rightTouchpadVector2;
    }
}
