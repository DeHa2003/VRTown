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
    private VibrationDevice vibration;

    private Hand hand;

    public GameObject grabbingObj;
    public bool isGrabbing = false;

    private void Awake()
    {
        color = SettingsScript.colorLaserDefault;
        clickColor = SettingsScript.colorLaserClick;
        vibration = GameObject.FindWithTag("SceneManager").GetComponent<VibrationDevice>();
        hand = GetComponent<Hand>();
    }
    public override void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("UI"))
        {
            e.target.GetComponent<UIButton>().Select();
            vibration.Pulse(0, 20, 0.1F, GetComponent<Hand>().handType);
        }
        if (e.target.CompareTag("VR Item"))
        {
            vibration.Pulse(0, 20, 0.1F, GetComponent<Hand>().handType);
            grabbingObj = e.target.gameObject;
            isGrabbing = true;
        }
    }
    private void FixedUpdate()
    {
        if(isGrabbing)
        {
            var a = grabbingObj.GetComponent<Rigidbody>();
            if(hand.grabPinchAction.GetStateDown(hand.handType))
            {
                //a.isKinematic = true;
                a.AddForce(40000 * Time.deltaTime * -transform.forward + new Vector3(0, 0.7f, 0));
            }
        }
    }
    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerClick(e);
        if (e.target.CompareTag("UI"))
        {
            e.target.GetComponent<UIButton>().Click();
            e.target.GetComponent<Button>().onClick.Invoke();
        }
        else if (e.target.CompareTag("Interaction"))
        {
            e.target.GetComponent<InteractableHoverEvents>().onHandHoverBegin.Invoke();
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerOut(e);
        if (e.target.CompareTag("UI"))
        {
            e.target.GetComponent<UIButton>().UnSelect();
            vibration.Pulse(0, 20, 0.1F, GetComponent<Hand>().handType);
        }
        if (e.target.CompareTag("VR Item"))
        {
            grabbingObj = null;
            isGrabbing = false;
        }
    }
    private void OnDestroy()
    {
        Destroy(holder);
    }
}
