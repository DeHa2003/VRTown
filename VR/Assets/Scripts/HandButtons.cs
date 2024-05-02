using System;
using UnityEngine;
using Valve.VR;

public class HandButtons : MonoBehaviour
{

    public bool isNoneVR = false;

    public event Action<float> OnChangedValueSqueeze_LeftHand;
    public event Action<float> OnChangedValueSqueeze_RightHand;

    public event Action<Vector2> OnChangedValueTouchpad_LeftHand;
    public event Action<Vector2> OnChangedValueTouchpad_RightHand;

    public event Action OnClickTriggerLeftHand;
    public event Action OnClickTriggerRightHand;
    public event Action OnClickUpperRightHandMenu;
    public event Action OnClickUpperLeftHandMenu;

    [SerializeField] private SteamVR_Action_Single squeeze;
    [SerializeField] private SteamVR_Action_Boolean UPPER_BUTTON;
    [SerializeField] private SteamVR_Action_Boolean trigger;
    [SerializeField] private SteamVR_Action_Vector2 touchpad_Left;
    [SerializeField] private SteamVR_Action_Vector2 touchpad_Right;

    private float leftSqueezeVector1;
    private float rightSqueezeVector1;

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

            if (UPPER_BUTTON.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                OnClickUpperRightHandMenu?.Invoke();
            }

            if (trigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                OnClickTriggerLeftHand?.Invoke();
            }

            if (trigger.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                OnClickTriggerRightHand?.Invoke();
            }

            leftTouchpadVector2 = touchpad_Left.GetAxis(SteamVR_Input_Sources.LeftHand); 
            OnChangedValueTouchpad_LeftHand?.Invoke(leftTouchpadVector2);

            rightTouchpadVector2 = touchpad_Right.GetAxis(SteamVR_Input_Sources.RightHand);
            OnChangedValueTouchpad_RightHand?.Invoke(rightTouchpadVector2);

            leftSqueezeVector1 = squeeze.GetAxis(SteamVR_Input_Sources.LeftHand);
            OnChangedValueSqueeze_LeftHand?.Invoke(leftSqueezeVector1);

            rightSqueezeVector1 = squeeze.GetAxis(SteamVR_Input_Sources.RightHand);
            OnChangedValueSqueeze_RightHand?.Invoke(rightSqueezeVector1);
        }
    }

    public void AddActionToUpperButton_LeftHand(Action action)
    {
        OnClickUpperLeftHandMenu += action;
    }

    public void RemoveActionToUpperButton_LeftHand(Action action)
    {
        OnClickUpperLeftHandMenu -= action;
    }



    public void AddActionToUpperButton_RightHand(Action action)
    {
        OnClickUpperRightHandMenu += action;
    }

    public void RemoveActionToUpperButton_RightHand(Action action)
    {
        OnClickUpperRightHandMenu -= action;
    }


    public void AddActionToTriggerButton_LeftHand(Action action)
    {
        OnClickTriggerLeftHand += action;
    }

    public void RemoveActionToTriggerButton_LeftHand(Action action)
    {
        OnClickTriggerLeftHand -= action;
    }


    public void AddActionToTriggerButton_RightHand(Action action)
    {
        OnClickTriggerRightHand += action;
    }

    public void RemoveActionToTriggerButton_RightHand(Action action)
    {
        OnClickTriggerRightHand -= action;
    }



    public float GetLeftSqueezeData()
    {
        return leftSqueezeVector1;
    }

    public float GetRightSqueezeData()
    {
        return rightSqueezeVector1;
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
