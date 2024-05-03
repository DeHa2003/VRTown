using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Trigger_Wheel : Trigger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GamePlayer>() || other.GetComponent<Camera>())
        {
            if (isActive)
            {
                Debug.Log(this.name);
                if (playerController != null)
                    playerController.SetPlayerFailedState_Wheel();
            }
        }
    }
}
