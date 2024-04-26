using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Trigger_Wheel : Trigger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<GamePlayer>())
        {
            Debug.Log(this.name);
            if (playerController != null)
               playerController.SetPlayerFailedState();
        }
    }
}
