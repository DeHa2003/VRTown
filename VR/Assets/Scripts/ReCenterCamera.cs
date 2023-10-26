using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ReCenterCamera : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var system = OpenVR.System;
            if (system != null)
            {
                SteamVR.instance.hmd.GetRawZeroPoseToStandingAbsoluteTrackingPose();
            }
        }
    }
}
