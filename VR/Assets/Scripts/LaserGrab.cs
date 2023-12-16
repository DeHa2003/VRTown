
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class LaserGrab : MonoBehaviour
{
    public UnityEvent OnGrab;
    public GameObject AttachedObj { get; private set; }

    [SerializeField] private LaserGrab otherLaserGrab;
    [SerializeField] private float time;

    private bool isAttached = false;
    public void GrabObject(GameObject attachedObj)
    {
        otherLaserGrab.UnGrubObject();

        if(this.AttachedObj != null) 
        { 
            if(AttachedObj == attachedObj)
            {
                UnGrubObject();
                return;
            }
            UnGrubObject(); 
        }

        OnGrab?.Invoke();
        isAttached = true;
        this.AttachedObj = attachedObj;
        this.AttachedObj.layer = 6;
        this.AttachedObj.GetComponent<Rigidbody>().isKinematic = true;
        attachedObj.GetComponent<Throwable>().onDetachFromHand.AddListener(UnGrubObject);
    }

    private void Update()
    {
        if (!isAttached) { return; }

        this.AttachedObj.transform.position = Vector3.Lerp(AttachedObj.transform.position, transform.position, time * Time.deltaTime);

    }

    private void UnGrubObject()
    {
        isAttached = false;

        if (AttachedObj)
        {
            AttachedObj.GetComponent<Rigidbody>().isKinematic = false;
            AttachedObj.layer = 0;
            AttachedObj = null;
        }
    }
}
