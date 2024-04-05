using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
public class LaserScript : SteamVR_LaserPointer
{
    //private VibrationDeviceControl vibration;

    private Hand hand;

    private LaserGrab laserGrab;

    private void Awake()
    {
        color = SettingsScript.colorLaserDefault;
        clickColor = SettingsScript.colorLaserClick;
        //vibration = GameObject.FindWithTag("PlayerControls").GetComponent<VibrationDeviceControl>();
        hand = GetComponent<Hand>();
        laserGrab = GetComponent<LaserGrab>();
    }

    public override void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);

        if (e.target.TryGetComponent(out UIButton iButton))
        {
            iButton.Select();
            //vibration.Vibration(0, 20, 0.1F, GetComponent<Hand>().handType);
        }
        if (e.target.TryGetComponent(out Interactable interactable))
        {
            interactable.OnHandHoverBegin(hand);
            //vibration.Vibration(0, 20, 0.1F, GetComponent<Hand>().handType);
        }
    }

    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerClick(e);

        if (e.target.TryGetComponent(out UIButton iButton))
        {
            iButton.Click();
        }
        else if (e.target.TryGetComponent(out Interactable interactable))
        {
            interactable.OnHandHoverEnd(hand);

            if(interactable.TryGetComponent(out InteractableHoverEvents interactableHoverEvents))
            {
                interactableHoverEvents.onHandHoverBegin.Invoke();
            }

            if(interactable.TryGetComponent(out Throwable throwable))
            {
                laserGrab.GrabObject(throwable.gameObject);
            }
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerOut(e);

        if (e.target.TryGetComponent(out UIButton iButton))
        {
            iButton.UnSelect();
            //vibration.Vibration(0, 20, 0.1F, GetComponent<Hand>().handType);
        }
        else if(e.target.TryGetComponent(out Interactable interactable))
        {
            interactable.OnHandHoverEnd(hand);
            //vibration.Vibration(0, 20, 0.1F, GetComponent<Hand>().handType);
        }
    }

    private void OnDestroy()
    {
        Destroy(holder);
    }
}
